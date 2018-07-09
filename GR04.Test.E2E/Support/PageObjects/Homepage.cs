using System;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System.Configuration;
using GR04.Test.E2E.Support.HelpObjects;

namespace GR04.Test.E2E.Support.PageObjects
{
    public class Homepage
    {
        public static NgWebDriver _ngDriver;



        //[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModelFinder), Using = "query")]
        //private IWebElement _searchBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[ui-sref='app.login']")]
        private IWebElement _signIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[ui-sref='app.register']")]
        private IWebElement _signUp { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[ui-sref='app.home']")]
        public IWebElement _homeLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[ui-sref='app.profile.main({ username: $ctrl.currentUser.username})']")]
        public IWebElement _username { get; set; }



        public String itemPrice;

        private IWebElement _product;


        public Homepage(IWebDriver driver, String url)
        {
            _ngDriver = new NgWebDriver(driver);
            _ngDriver.Url = url;
            _ngDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(Driver.CurrentDriver, this);

        }

        public void SelectSignUp()
        {
            _signUp.Click();
        }

        public void SelectSignIn()
        {
            _signIn.Click();
        }

    }
}
