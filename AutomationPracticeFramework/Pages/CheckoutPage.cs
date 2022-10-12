using AutomationPracticeFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class CheckoutPage : Base
    {
        readonly IWebDriver driver;

        public By checkoutPage = By.Id("order");
        public By checkoutProduct = By.CssSelector("td.cart_description p.product-name a");

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(checkoutPage));
        }
    }
}
