using OpenQA.Selenium;
using System.Collections.Generic;

namespace UBS.Automation.PageObjects
{
    public class SearchResults
    {
        private IWebDriver _driver;

        public SearchResults(IWebDriver driver)
        {
            _driver = driver;
        }

        private IEnumerable<IWebElement> _searchResultHighlightedTextPhrases
        {
            get { return _driver.FindElements(By.XPath("//p[@class='summary']/span[@class='highlight']")); }
        }

        private IWebElement _titleNoResults
        {
            get { return _driver.FindElement(By.ClassName("no-results-title")); }
        }

        public bool CheckAllHighlightedTextPhrasesContainStringEqualTo(List<string> expectedTextPhrases)
        {
            foreach(IWebElement highlightedTextPhrase in _searchResultHighlightedTextPhrases)
            {
                if (!expectedTextPhrases.Contains(highlightedTextPhrase.Text))
                    return false;
            }

            return true;
        }

        public string GetNoResultsTitle()
        {
            return _titleNoResults.Text;
        }
    }
}
