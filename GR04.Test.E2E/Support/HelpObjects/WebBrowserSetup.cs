using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Protractor;
using System.Configuration;

namespace GR04.Test.E2E.Support.HelpObjects
{
    [Binding]
    class WebBrowserSetup
    {
        private static string abrowser;
        NgWebDriver ngDriver;

        public WebBrowserSetup()
        {
            abrowser = ConfigurationManager.AppSettings["abrowser"];
        }

        public void StartWebBrowser()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();

            switch (abrowser)
            {

                case "Firefox":
                    FirefoxBinary firefoxBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                    FirefoxProfile fireFoxProfile = new FirefoxProfile { AcceptUntrustedCertificates = true };
                    Driver.CurrentDriver = new FirefoxDriver(firefoxBinary, fireFoxProfile);
                    Driver.CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    Driver.CurrentDriver.Manage().Window.Maximize();
                    ngDriver = new NgWebDriver(Driver.CurrentDriver);
                    break;
                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    Driver.CurrentDriver = new ChromeDriver();
                    Driver.CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    Driver.CurrentDriver.Manage().Window.Maximize();
                    //ngDriver = new NgWebDriver(Driver.CurrentDriver);
                    break;
                case "IE32":
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.EnableNativeEvents = false;
                    options.RequireWindowFocus = true;
                    options.AddAdditionalCapability("ACCEPT_SSL_CERTS", true);
                    Driver.CurrentDriver = new InternetExplorerDriver();
                    Driver.CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    Driver.CurrentDriver.Manage().Window.Maximize();
                    ngDriver = new NgWebDriver(Driver.CurrentDriver);
                    break;
                case "IE64":
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.EnableNativeEvents = false;
                    options.RequireWindowFocus = true;
                    options.AddAdditionalCapability("ACCEPT_SSL_CERTS", true);
                    Driver.CurrentDriver = new InternetExplorerDriver(string.Empty);
                    Driver.CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    Driver.CurrentDriver.Manage().Window.Maximize();
                    ngDriver = new NgWebDriver(Driver.CurrentDriver);
                    break;

                default:
                    System.Console.WriteLine("Browser Selected Not Supported");
                    break;
            }

        }


    }
}

