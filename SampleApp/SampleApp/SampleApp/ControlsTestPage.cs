using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SampleApp
{
    public class ControlsTestPage : ContentPage
    {
        public ControlsTestPage()
        {
            var myLabel = new Label {Text = "Hello User"};


            var checkTapGestureLabel = new Label()
            {
                Text = "checkTapGestureLabel Click"
            };
            TapGestureRecognizer checkTapGestureLabelTapGesture = new TapGestureRecognizer();
            checkTapGestureLabelTapGesture.Tapped += (s, e) =>
            {
                myLabel.Text = "Was clicked";
                //DisplayAlert("Testapp", "tapped!!!", "Ok");
            };
            checkTapGestureLabel.GestureRecognizers.Add(checkTapGestureLabelTapGesture);



            Button firstTestButton = new Button() {Text = "Test first Click"};



            Content = new StackLayout
            {
                Children = {
                    myLabel,
                    firstTestButton,
                    checkTapGestureLabel,
                }
            };
        }
    }
}
