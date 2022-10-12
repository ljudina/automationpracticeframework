using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class PLPPage
    {
        readonly IWebDriver driver;

        public By pageLocator = By.Id("category");
        public By firstProduct = By.ClassName("product_img_link");

        public PLPPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(pageLocator));
        }
    }
}
