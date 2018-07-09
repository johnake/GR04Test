using OpenQA.Selenium;
using Protractor;
using OpenQA.Selenium.Support.PageObjects;
using GR04.Test.E2E.Support.HelpObjects;

namespace GR04.Test.E2E.Support.PageObjects
{
    public class RegisterPage
    {
        private static NgWebDriver _ngDriver;

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Proceed to Cart')]")]
        private IWebElement _btnProceedToCart { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModelFinder), Using = "$ctrl.formData.username")]
        private IWebElement _username { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModelFinder), Using = "$ctrl.formData.email")]
        private IWebElement _email { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModelFinder), Using = "$ctrl.formData.password")]
        private IWebElement _password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement _signUpButton { get; set; }
        

        //$ctrl.formData.username

        //$ctrl.formData.email

        //$ctrl.formData.password


        public RegisterPage(IWebDriver driver)
        {
            _ngDriver = new NgWebDriver(driver);
            PageFactory.InitElements(Driver.CurrentDriver, this);

        }

        public void EnterSignUpDetails(string username, string email, string password)
        {
            _username.SendKeys(username);
            _email.SendKeys(email);
            _password.SendKeys(password);
            _signUpButton.Click();
        }

        public void EnterSignInDetails(string email, string password)
        {
            _email.SendKeys(email);
            _password.SendKeys(password);
            _signUpButton.Click();
        }

        public class NgByModelFinder : By
        {
            public NgByModelFinder(string locator)
            {
                FindElementMethod = context => _ngDriver.FindElement(NgBy.Model(locator));

            }
        }

        public class NgByBindFinder : By
        {
            public NgByBindFinder(string locator)
            {
                FindElementMethod = context => _ngDriver.FindElement(NgBy.Binding(locator));

            }
        }
    }
}
