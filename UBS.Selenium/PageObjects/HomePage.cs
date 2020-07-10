using OpenQA.Selenium;
using System.Configuration;

namespace UBS.Automation.PageObjects
{
    public class HomePage
    {
        private string url = ConfigurationManager.AppSettings["url"];
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;                       
        }

        public HomePage Open()
        {
            _driver.Navigate().GoToUrl(url);

            if (_iframePrivacySettings.Displayed)
            {
                _driver.SwitchTo().ParentFrame();
                _driver.SwitchTo().Frame(_iframePrivacySettings);
                _buttonAgreeToAll.Click();
                _driver.SwitchTo().ParentFrame();
            }

            return new HomePage(_driver);
        }

        private IWebElement _buttonAgreeToAll
        {
            get { return this._driver.FindElement(By.XPath("//button[@class='actionbutton__button privacysettings__allowAllCookies']")); }
        }

        private IWebElement _buttonOpenSearch
        {
            get { return this._driver.FindElement(By.XPath("//button[@aria-label='Search']")); }
        }

        private IWebElement _buttonPerformSearch
        {
            get { return this._driver.FindElement(By.ClassName("search-button")); }
        }        

        private IWebElement _buttonUbsLogins
        {
            get { return this._driver.FindElement(By.XPath("//button[@data-di-id='menulabel-login']")); }
        }

        private IWebElement _textboxSearch
        {
            get { return this._driver.FindElement(By.ClassName("searchbox")); }
        }

        private IWebElement _menuItemUbsDigitalNetworksAndEvents
        {
            get { return this._driver.FindElement(By.XPath("//a[text()='UBS Digital Networks and Events']")); }
        }

        private IWebElement _iframePrivacySettings
        {
            get { return this._driver.FindElement(By.ClassName("cboxIframe")); }
        }

        public DigitalNetworksLoginPage NavigateToDigitalNetworksLoginPage()
        {
            _buttonUbsLogins.Click();
            _menuItemUbsDigitalNetworksAndEvents.Click();

            return new DigitalNetworksLoginPage(_driver);
        }

        public SearchResults PerformSearch(string searchQuery)
        {
            _buttonOpenSearch.Click();
            _textboxSearch.SendKeys(searchQuery);
            _buttonPerformSearch.Click();
            return new SearchResults(_driver);
        }
    }
}