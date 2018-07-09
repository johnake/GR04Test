using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GR04.Test.E2E.Support.HelpObjects
{
    public class Utilities
    {
        public static void SelectFromDropdown(IWebElement element, string value)
        {
            SelectElement s = new SelectElement(element);
                s.SelectByValue(value);
        }

    }
}
