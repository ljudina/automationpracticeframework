using AutomationPracticeFramework.Helpers;
using AutomationPracticeFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class ContactUsSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HomePage hp = new HomePage(Driver);

        [Given(@"User opens contact us page")]
        public void GivenUserOpensContactUsPage()
        {
            ut.ClickOnElement(hp.contactUs);
        }
        
        [When(@"User fill in all required fields with ""(.*)"" heading and ""(.*)"" message")]
        public void WhenUserFillInAllRequiredFieldsWithHeadingAndMessage(string heading, string message)
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.DropdownSelect(cup.subjectHeading, heading);
            ut.EnterTextInElement(cup.contactEmail, ut.GenerateRandomEmail());
            ut.EnterTextInElement(cup.message, message);
        }

        [When(@"User submits form")]
        public void WhenUserSubmitsForm()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.ClickOnElement(cup.sendBtn);
        }
        
        [Then(@"message ""(.*)"" is present to the team")]
        public void ThenMessageIsPresentToTheTeam(string message)
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            Assert.That(ut.ReturnTextFromElement(cup.successMessage), Is.EqualTo(message), "Message was not send to customer service");
        }
    }
}
