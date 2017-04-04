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

        //static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("MyLabel").Text("Hello User");

        //static readonly Func<AppQuery, AppQuery> Button = c => c.Marked("MyButton");

        //static readonly Func<AppQuery, AppQuery> DoneMessage = c => c.Marked("MyLabel").Text("Was clicked");



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
            //app.Repl();

            //// Arrange - Nothing to do because the queries have already been initialized.

            //AppResult[] result = app.Query(InitialMessage);

            //Assert.IsTrue(result.Any(), "The initial message string isn't correct - maybe the app wasn't re-started?");



            //// Act

            //app.Tap(Button);



            //// Assert

            //result = app.Query(DoneMessage);

            //Assert.IsTrue(result.Any(), "The 'clicked' message is not being displayed.");

            app.Screenshot("First screen");
            //app.Tap(c=>c.Button().Text("Go to Controls test page"));

            app.Tap(c => c.Marked("Go to Controls test page"));
            //app.Tap(c=>c.Marked("checkTapGestureLabel").Text("checkTapGestureLabel Click"));
            app.Screenshot("Second screen");

            app.Tap(c=>c.Marked("Test first Click"));
            app.Screenshot("3 screen");

            //app.Repl();
            //app.Screenshot("First screen.");
            //app.Tap(c => c.Marked("BtnNavToTable"));
            //app.Screenshot("Second screen.");
            //app.EnterText("txtText", "Hello World");
        }

        //[Test]
        //public void CheckControls()
        //{
        //    app.Screenshot("1 screen : Check Controls started");
        //    app.Query(c => c.Marked("BtnNavToControlTestPage"));
        //    app.Screenshot("2 screen : ControlsTestPage marked");
        //    app.Tap(c => c.Marked("BtnNavToControlTestPage"));
        //    app.Screenshot("3 screen : BtnNavToControlTestPage Tap");


        //    //app.Repl();
        //    //app.Screenshot("1 screen : Check Controls started");
        //    //app.Tap(c => c.Button("BtnNavToControlTestPage"));
        //    //app.Screenshot("2 screen : ControlsTestPage loaded");
        //    //app.Tap(c => c.Id("checkTapGestureLabel"));
        //    //app.Screenshot("3 screen : checkTapGestureLabel tap Done!!!");
        //}
    }
}

