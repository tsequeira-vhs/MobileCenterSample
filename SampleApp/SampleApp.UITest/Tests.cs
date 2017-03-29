using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace SampleApp.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.Tap(c => c.Marked("BtnNavToTable"));
            app.Screenshot("Second screen.");
            app.EnterText("txtText", "Hello World");
        }

        [Test]
        public void CheckControls()
        {
            app.Screenshot("1 screen : Check Controls started");
            app.Tap(c => c.Marked("BtnNavToControlTestPage"));
            app.Screenshot("2 screen : ControlsTestPage loaded");
            app.Tap(c => c.Marked("checkTapGestureLabel"));
            app.Screenshot("3 screen : checkTapGestureLabel tap Done!!!");
        }
    }
}

