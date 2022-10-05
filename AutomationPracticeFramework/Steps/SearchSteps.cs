using AutomationPracticeFramework.Helpers;
using AutomationPracticeFramework.Pages;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class SearchSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HomePage hp = new HomePage(Driver);        

        [Given(@"user enters '(.*)' search term")]
        public void GivenUserEntersSearchTerm(string term)
        {
            ut.EnterTextInElement(hp.search, term);            
        }
        
        [When(@"use submits a search")]
        public void WhenUseSubmitsASearch()
        {
            ut.ClickOnElement(hp.searchButton);
        }
        
        [Then(@"results for '(.*)' search term are displayed")]
        public void ThenResultsForSearchTermAreDisplayed(string term)
        {
            SearchPage sp = new SearchPage(Driver);
            Assert.That(ut.ReturnTextFromElement(sp.searchResults), Does.Contain(term), "Wrong search results found");
        }
    }
}
