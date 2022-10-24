using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class MyAccountPage
    {
        readonly IWebDriver driver;

        public By myAccountPage = By.Id("my-account");
        public By myAccountValidator = By.CssSelector("h1.page-heading");
        public By wishlistPage = By.ClassName("lnk_wishlist");
        public By personalInformationPage = By.CssSelector("a[title=\"Information\"]");

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(myAccountPage));
        }
    }
}
