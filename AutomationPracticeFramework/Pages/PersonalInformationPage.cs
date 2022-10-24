using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class PersonalInformationPage
    {
        readonly IWebDriver driver;

        public By personalInformationPage = By.Id("identity");
        public By customerLastName = By.Id("lastname");
        public By customerOldPassword = By.Id("old_passwd");
        public By saveButton = By.CssSelector("button[name='submitIdentity']");
        public By accountName = By.ClassName("account");

        public PersonalInformationPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(personalInformationPage));
        }
    }
}
