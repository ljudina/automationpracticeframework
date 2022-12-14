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
        private readonly WishlistData wishlistData;

        public MyAccountSteps(PersonData personData, WishlistData wishlistData)
        {
            this.personData = personData;
            this.wishlistData = wishlistData;
        }

        [Given(@"User opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            ut.ClickOnElement(hp.signIn);
        }
        
        [StepDefinition(@"user enters credentials")]
        public void GivenUserEntersCredentials()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.email, TestConstants.Username);
            ut.EnterTextInElement(ap.password, TestConstants.Password);
        }
        
        [StepDefinition(@"user submits sign in")]
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

        [Given(@"user goes to My Wishlist page")]
        public void GivenUserGoesToMyWishlistPage()
        {
            MyAccountPage map = new MyAccountPage(Driver);
            ut.ClickOnElement(map.wishlistPage);
        }

        [Given(@"user enters whishlist name")]
        public void WhenUserEntersWhishlistName()
        {
            WishlistPage wp = new WishlistPage(Driver);
            wishlistData.Name = ut.GenerateRandomString(8);
            ut.EnterTextInElement(wp.wishlistInput, wishlistData.Name);
        }

        [When(@"user submits whishlist name")]
        public void WhenUserSubmitsWhishlistName()
        {
            WishlistPage wp = new WishlistPage(Driver);
            ut.ClickOnElement(wp.wishlistSubmit);
        }

        [Then(@"whishlist name is displayed")]
        public void ThenWhishlistNameIsDisplayed()
        {
            Assert.True(ut.TextPresentInElement(wishlistData.Name).Displayed, "Wishlist name is not displayed");
        }

        [Given(@"user goes to My personal information page")]
        public void GivenUserGoesToMyPersonalInformationPage()
        {
            MyAccountPage map = new MyAccountPage(Driver);
            ut.ClickOnElement(map.personalInformationPage);
        }

        [Given(@"user changes last name")]
        public void GivenUserChangesLastName()
        {
            PersonalInformationPage pip = new PersonalInformationPage(Driver);
            ut.ClearInputField(pip.customerLastName);
            personData.LastName = ut.GenerateRandomString(8);
            ut.EnterTextInElement(pip.customerLastName, personData.LastName);
            ut.EnterTextInElement(pip.customerOldPassword, TestConstants.Password);
        }

        [When(@"user submits personal information name")]
        public void WhenUserSubmitsPersonalInformationName()
        {
            PersonalInformationPage pip = new PersonalInformationPage(Driver);
            ut.ClickOnElement(pip.saveButton);
        }

        [Then(@"new last name is shown")]
        public void ThenNewLastNameIsShown()
        {
            PersonalInformationPage pip = new PersonalInformationPage(Driver);
            Assert.That(ut.ReturnTextFromElement(pip.accountName), Does.Contain(personData.LastName), "Changed last name is not displayed");
        }


    }
}
