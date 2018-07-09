using TechTalk.SpecFlow;
using System.Configuration;
using GR04.Test.E2E.Support.PageObjects;
using GR04.Test.E2E.Support.HelpObjects;
namespace GR04.Test.E2E.StepDefinitions
{
    [Binding]
    public class RegisterPageSteps
    {
        RegisterPage _registrationPage;

        public RegisterPageSteps()
        {
            _registrationPage = new RegisterPage(Driver.CurrentDriver);
        }

        [When(@"the user signs up with details (.*), (.*), (.*)")]
        public void WhenTheUserSignsUpWithDetails(string username, string email, string password)
        {
            _registrationPage.EnterSignUpDetails(username, email, password);
        }

        [When(@"the user enters username ""(.*)"" and password ""(.*)""")]
        public void WhenTheUserEntersUsernameAndPassword(string email, string password)
        {
            _registrationPage.EnterSignInDetails(email, password);
        }

    }
}
