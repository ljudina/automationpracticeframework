using AutomationPracticeFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class PDPPage : Base
    {
        readonly IWebDriver driver;

        public By pageLocator = By.Id("product");
        public By quantity = By.Id("quantity_wanted");
        public By productName = By.XPath("//h1[@itemprop='name']");

        public By addToCard = By.Id("add_to_cart");

        public PDPPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(pageLocator));
        }
    }
}
