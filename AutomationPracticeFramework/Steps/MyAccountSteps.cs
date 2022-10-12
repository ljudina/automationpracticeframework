using AutomationPracticeFramework.Helpers;
using AutomationPracticeFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class MyAccountSteps : Base
    {
        HomePage hp = new HomePage(Driver);        
        Utilities ut = new Utilities(Driver);

        private readonly PersonData personData;

        public MyAccountSteps(PersonData personData)
        {
            this.personData = personData;
        }

        [Given(@"User opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            ut.ClickOnElement(hp.signIn);
        }
        
        [Given(@"user enters credentials")]
        public void GivenUserEntersCredentials()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.email, TestConstants.Username);
            ut.EnterTextInElement(ap.password, TestConstants.Password);
        }
        
        [When(@"user submits sign in")]
        public void WhenUserSubmitsSignIn()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.signInButton);
        }
        
        [StepDefinition(@"user is logged in to my account section")]
        public void ThenUserIsLoggedInToMyAccountSection()
        {
            MyAccountPage map = new MyAccountPage(Driver);
            Assert.That(ut.ReturnTextFromElement(map.myAccountValidator), Is.EqualTo("MY ACCOUNT"), "Page 'My account' was not found");
        }

        [Given(@"user enters email in create account section and submits")]
        public void GivenUserEntersEmailInCreateAccountSection()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            personData.GeneratedEmail = ut.GenerateRandomEmail();
            ut.EnterTextInElement(ap.createEmail, personData.GeneratedEmail);
            ut.ClickOnElement(ap.submitCreate);
        }

        [Given(@"user enters all required fields for account creation")]
        public void GivenUserEntersAllRequiredFieldsForAccountCreation()
        {
            CreateAccountPage cap = new CreateAccountPage(Driver);
            personData.FullName = TestConstants.RegisterFirstName + " " + TestConstants.RegisterLastName;
            ut.EnterTextInElement(cap.customerFirstName, TestConstants.RegisterFirstName);
            ut.EnterTextInElement(cap.customerLastName, TestConstants.RegisterLastName);
            ut.EnterTextInElement(cap.customerPassword, TestConstants.RegisterPassword);
            ut.EnterTextInElement(cap.customerAddress, TestConstants.RegisterAddress);
            ut.EnterTextInElement(cap.customerCity, TestConstants.RegisterCity);
            ut.DropdownSelect(cap.customerState, TestConstants.RegisterState);
            ut.EnterTextInElement(cap.customerZip, TestConstants.RegisterZip);
            ut.EnterTextInElement(cap.customerMobile, TestConstants.RegisterMobile);
        }

        [When(@"user submits registration")]
        public void WhenUserSubmitsRegistration()
        {
            CreateAccountPage cap = new CreateAccountPage(Driver);
            ut.ClickOnElement(cap.submitAccount);
        }

        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            GivenUserOpensSignInPage();
            GivenUserEntersCredentials();
            WhenUserSubmitsSignIn();
        }

        [When(@"users full name is displayed")]
        public void WhenUsersFullNameIsDisplayed()
        {
            Assert.True(ut.TextPresentInElement(personData.FullName).Displayed, "User's full name is not displayed");
        }


    }
}
