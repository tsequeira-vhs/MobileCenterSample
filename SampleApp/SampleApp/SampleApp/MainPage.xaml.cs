using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ////This callback will be invoked just before the crash is sent to Mobile Center
            //Crashes.SendingErrorReport += (sender, e) =>
            //{
            //};

            //// This callback will be invoked after sending a crash report succeeded
            //Crashes.SentErrorReport += (sender, e) =>
            //{
            //};

            ////This callback will be invoked after sending a crash report failed
            //Crashes.FailedToSendErrorReport += (sender, e) =>
            //{
            //};
        }


        private async void btn_Clicked(object sender, EventArgs e)
        {
            ////At any time after starting the SDK, you can check if the app crashed in the previous session
            //bool didAppCrash = Crashes.HasCrashedInLastSession;

            ////Enable disable crash
            //Crashes.Enabled = true;

            ////check if the module is enabled or not
            //bool isEnabled = Crashes.Enabled;

            //// If your app crashed previously, you can get details about the last crash
            //ErrorReport crashReport = await Crashes.GetLastSessionCrashReportAsync();

            ////some ignore cases when you dont with  to log that crash case
            //Crashes.ShouldProcessErrorReport = (report) =>
            //{
            //    return true; // return true if the crash report should be processed, otherwise false.
            //};

            ////await user confirmation before sending any crash
            //Crashes.ShouldAwaitUserConfirmation = () =>
            //{
            //    return true; // Return true if the SDK should await user confirmation, otherwise false.
            //};
            ////Pass one of UserConfirmation.Send, UserConfirmation.DontSend or UserConfirmation.AlwaysSend in NotifyUserConfirmation.
            //Crashes.NotifyUserConfirmation(UserConfirmation confirmation);


            //Generate crash
            Crashes.GenerateTestCrash();
        }

        private void btnLogHandledException_Clicked(object sender, EventArgs e)
        {
            try
            {
                //int[] myValues = new int[1];
                //string sstest = myValues[3].ToString();

                //throw new NotSupportedException();

                var a = Convert.ToInt32("convertError");
            }
            catch (Exception ex)
            {
                // Analytics.TrackEvent(
                //    this.ToString() + ".btnLogHandledException_Clicked()",
                //    new Dictionary<string, string>
                //    {
                //         { ex.Message, "StackTrace : " + ex.StackTrace}//"CreatedOn : " + DateTime.UtcNow.ToLocalTime().ToString() + 
                //    }
                //);

                Analytics.TrackEvent(
                    this.ToString() + ".btnLogHandledException_Clicked()",
                    new Dictionary<string, string>
                    {
                        { "Type", ex.GetType().ToString() },
                        { "Message", ex.Message },
                        { "StackTrace", ex.StackTrace},
                        { "CreatedOn",DateTime.UtcNow.ToLocalTime().ToString()}
                    }
                );
            }
        }

        private void BtnNavToTable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TableDataPage());
        }
    }
}