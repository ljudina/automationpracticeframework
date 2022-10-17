using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class WishlistPage
    {
        readonly IWebDriver driver;

        public By wishlistPage = By.Id("module-blockwishlist-mywishlist");
        public By wishlistInput = By.Id("name");
        public By wishlistName = By.CssSelector(".table tr td a");
        public By wishlistSubmit = By.Id("submitWishlist");

        public WishlistPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(wishlistPage));
        }
    }
}
