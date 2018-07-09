using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace GR04.Test.E2E.Support.HelpObjects
{
    public static class WebDriverExtensions
    {
        internal static bool WaitUntilDisplayed(this IWebDriver webDriver, IWebElement element, int time = 10)
        {
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(time)).Until(driver => element.Displayed);
        }
    }
}
