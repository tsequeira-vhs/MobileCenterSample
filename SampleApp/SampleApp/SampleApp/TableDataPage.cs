using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;

using Xamarin.Forms;
using SampleApp.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SampleApp
{
    public class TableDataPage : ContentPage
    {
        MobileServiceClient client = new MobileServiceClient("https://mobile-2638566c-8321-47a4-9ad4-43d1d99ea152.azurewebsites.net/");

        public TableDataPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello Page" },
                }
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //IMobileServiceTable<Settings> settingsTable = client.GetTable<Settings>();
            //var settingsList = (await settingsTable.ReadAsync()).ToList();

            // To get value of setting with key Setting1
            //string valueOfSetting1 = (await settingsTable.Where(x => x.Key == "Setting1").Select(x => x.Value).ToListAsync()).FirstOrDefault();

            var store = new MobileServiceSQLiteStore("MobileCenterDb");
            store.DefineTable<Settings>();

            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            await client.SyncContext.InitializeAsync(store);

            await SyncAsync();

            var table = client.GetSyncTable<Settings>();
            var some = await table.ToListAsync();
        }

        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();
                var settingsTable = client.GetSyncTable<Settings>();
                await settingsTable.PullAsync(
                    //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                    //Use a different query name for each unique query in your program
                    "allSettings",
                    settingsTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }
    }
}
