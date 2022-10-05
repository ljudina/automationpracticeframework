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

        [Given(@"User opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            ut.ClickOnElement(hp.signIn);
        }
        
        [Given(@"user enters '(.*)' for username")]
        public void GivenUserEntersForUsername(string email)
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.email, email);
        }
        
        [Given(@"user enters '(.*)' for password")]
        public void GivenUserEntersForPassword(string password)
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.password, password);
        }
        
        [When(@"user submits sign in")]
        public void WhenUserSubmitsSignIn()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.signInButton);
        }
        
        [Then(@"user is logged in to my account section")]
        public void ThenUserIsLoggedInToMyAccountSection()
        {
            MyAccountPage map = new MyAccountPage(Driver);
            Assert.That(ut.ReturnTextFromElement(map.myAccountValidator), Is.EqualTo("MY ACCOUNT"), "Page 'My account' was not found");
        }
    }
}
