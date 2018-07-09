using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Configuration;
using GR04.Test.E2E.Support.PageObjects;
using GR04.Test.E2E.Support.HelpObjects;
using NUnit.Framework;

namespace GR04.Test.E2E.StepDefinitions
{
    [Binding]
    public class HomepageSteps
    {

        private static string _url = ConfigurationManager.AppSettings["ConduitSiteUrl"];

        Homepage _homepage;

        [Given(@"a user is not logged in")]
        public void GivenAUserIsNotLoggedIn()
        {
            _homepage = new Homepage(Driver.CurrentDriver, _url);
        }

        [Given(@"the user selects signUp on the homepage")]
        public void GivenTheUserSelectsSignUpOnTheHomepage()
        {
            _homepage.SelectSignUp();
        }

        [Then(@"the user is logged in")]
        public void ThenTheUserIsLoggedIn()
        {
            Driver.CurrentDriver.WaitUntilDisplayed(_homepage._homeLink);
        }

        [Then(@"the users name (.*) is displayed")]
        public void ThenTheUsersNameJohnIsDisplayed(string username)
        {
            Driver.CurrentDriver.WaitUntilDisplayed(_homepage._username);
            Assert.That(_homepage._username.Text.Contains(username));
        }

        [When(@"the user selects signIn on the homepage")]
        public void WhenTheUserSelectsSignInOnTheHomepage()
        {
            _homepage.SelectSignIn();
        }
    }
}
