using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class SearchPage
    {
        readonly IWebDriver driver;

        public By searchPage = By.Id("search");
        public By searchResults = By.ClassName("lighter");

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(searchPage));
        }
    }
}
