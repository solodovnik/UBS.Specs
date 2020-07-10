using OpenQA.Selenium;

namespace UBS.Automation.PageObjects
{
    public class DigitalNetworksLoginPage
    {
        private IWebDriver _driver;

        public DigitalNetworksLoginPage(IWebDriver driver)
        {
            _driver = driver;

            if (_buttonAllowAllCookies.Displayed)
                _buttonAllowAllCookies.Click();
        }

        private IWebElement _buttonAllowAllCookies
        {
            get { return _driver.FindElement(By.XPath("//button[text()='Allow all cookies']")); }
        }

        private IWebElement _buttonLogIn
        {
            get { return _driver.FindElement(By.XPath("//button[@type='submit']")); }
        }

        private IWebElement _textboxEmail
        {
            get { return _driver.FindElement(By.Name("j_username")); }
        }

        private IWebElement _textboxPassword
        {
            get { return _driver.FindElement(By.Name("j_password")); }
        }

        private IWebElement _alertMessage
        {
            get { return _driver.FindElement(By.XPath("//div[@role='alert']")); }
        }

        public void EnterCredentials(string email, string password)
        {
            _textboxEmail.SendKeys(email);
            _textboxPassword.SendKeys(password);
        }

        public DigitalNetworksLoginPage ClickLogInButton()
        {
            _buttonLogIn.Click();
            return new DigitalNetworksLoginPage(_driver);
        }

        public string GetAlertMessage()
        {
            return _alertMessage.Text;
        }

    }
}