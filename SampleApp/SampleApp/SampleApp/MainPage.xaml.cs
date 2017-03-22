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
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            Crashes.GenerateTestCrash();
        }

        private void BtnNavToTable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TableDataPage());
        }
    }
}