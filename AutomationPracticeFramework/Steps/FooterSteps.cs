using AutomationPracticeFramework.Helpers;
using AutomationPracticeFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class FooterSteps : Base
    {
        FooterPage fp = new FooterPage(Driver);

        [When(@"User clicks on '(.*)' option")]
        public void WhenUserClicksOnOption(string title)
        {
            fp.ClickOnInformationLink(title);
        }
        
        [Then(@"correct '(.*)' is displayed")]
        public void ThenCorrectIsDisplayed(string page)
        {
            Assert.True(fp.InformationPageIsDisplayed(page), "Page is '" + page + "' not displayed");
        }
    }
}
