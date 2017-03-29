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
            var checkTapGestureLabel = new Label()
            {
                Text = "Check Tap Gesture"
            };
            TapGestureRecognizer checkTapGestureLabelTapGesture = new TapGestureRecognizer();
            checkTapGestureLabelTapGesture.Tapped += (s, e) =>
            {
                DisplayAlert("Testapp", "tapped!!!", "Ok");
            };
            checkTapGestureLabel.GestureRecognizers.Add(checkTapGestureLabelTapGesture);

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello User" },
                    checkTapGestureLabel,
                }
            };
        }
    }
}
