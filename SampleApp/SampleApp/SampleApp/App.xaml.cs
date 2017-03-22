using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Xamarin.Forms;

namespace SampleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SampleApp.MainPage());
        }

        protected override void OnStart()
        {
            MobileCenter.Start("android=1c171d60-ab72-4e42-a364-dede1066db08; ios=4e3488f1-ccc8-4cbd-b66d-8147ad684c96", typeof(Analytics), typeof(Crashes));
            //MobileCenter.Start("android=552c69b6-1e22-44f2-94c5-3edac5b31e21; ios=04bf8602-9fe6-4c46-b047-b073c0033a5e", typeof(Analytics), typeof(Crashes));
            // Handle when your app starts
        }

        protected override void OnSleep()
        {          

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
