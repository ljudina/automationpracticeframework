using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class CartPage 
    {
        readonly IWebDriver driver;

        public By cartPage = By.CssSelector("div#layer_cart");
        public By proceedToCheckout = By.CssSelector("a.btn[title='Proceed to checkout']");

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(cartPage));
        }
    }
}
