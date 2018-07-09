using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GR04.Test.E2E.Support.HelpObjects
{
    [Binding]
    public class SetupTeardown
    {
        private static readonly string TestScreenshotFolder = ConfigurationManager.AppSettings["TestErrorScreenShots"];

        [BeforeScenario]
        public static void BeforeScenario()
        {
            WebBrowserSetup webBrowserSetup = new WebBrowserSetup();
            webBrowserSetup.StartWebBrowser();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                // This means an error has occured
                var screenshot = ((ITakesScreenshot)Driver.CurrentDriver).GetScreenshot();

                screenshot.SaveAsFile(Path.Combine(TestScreenshotFolder, Environment.MachineName + "_" + ScenarioContext.Current.ScenarioInfo.Title + ".png"), ScreenshotImageFormat.Png);
            }
         
            Driver.CurrentDriver.Quit();

        }
    }
}
