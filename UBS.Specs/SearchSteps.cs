using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using UBS.Automation.PageObjects;

namespace UBS.Specs
{
    [Binding]
    public class SearchSteps
    {
        private HomePage _homePage;
        private SearchResults _searchResults;

        public SearchSteps(HomePage page)
        {
            _homePage = page;
        }

        [Given(@"I'm on Home page")]
        public void GivenIMOnHomePage()
        {
            _homePage.Open();
        }

        [When(@"I perform search by search query (.*)")]
        public void WhenIPerformSearchBySearchQuery(string query)
        {
            _searchResults = _homePage.PerformSearch(query);
        }

        [Then(@"all highlighted text phrases in search result summaries equal to (.*)")]
        public void ThenAllHighlightedTextPhrasesInSearchResultSummariesEqualTo(List<string> expectedPhrases)
        {
            _searchResults.CheckAllHighlightedTextPhrasesContainStringEqualTo(expectedPhrases);
        }

        [Then(@"the message (.*) should be displayed")]
        public void ThenTheMessageShouldBeDisplayed(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, _searchResults.GetNoResultsTitle());
        }

        [StepArgumentTransformation]
        public List<string> TransformToListOfString(string commaSeparatedList)
        {
            return commaSeparatedList.Split(new string[] { " or " }, StringSplitOptions.None).ToList();
        }
    }
}
