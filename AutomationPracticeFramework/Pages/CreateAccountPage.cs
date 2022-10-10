using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class CreateAccountPage
    {
        readonly IWebDriver driver;

        public By createAccountPage = By.Id("account-creation_form");
        public By customerFirstName = By.Id("customer_firstname");
        public By customerLastName = By.Id("customer_lastname");
        public By customerPassword = By.Id("passwd");
        public By customerAddress = By.Id("address1");
        public By customerCity = By.Id("city");
        public By customerState = By.Id("id_state");
        public By customerZip = By.Id("postcode");
        public By customerMobile = By.Id("phone_mobile");
        public By submitAccount = By.Id("submitAccount");


        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(createAccountPage));
        }
    }
}
