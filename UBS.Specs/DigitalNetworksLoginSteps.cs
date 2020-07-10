using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using UBS.Automation.PageObjects;

namespace UBS.Specs
{
    [Binding]
    public class DigitalNetworksLoginSteps
    {
        private HomePage _homePage;
        private DigitalNetworksLoginPage _digitalNetworksLoginPage;

        public DigitalNetworksLoginSteps(HomePage page)
        {
            _homePage = page;
        }

        [Given(@"I'm on Digital Networks Login page")]
        public void GivenIMOnDigitalNetworksLoginPage()
        {
            _digitalNetworksLoginPage = _homePage.Open().NavigateToDigitalNetworksLoginPage();
        }

        [Given(@"I have entered (.*) as Email and (.*) as Password")]
        public void GivenIHaveEnteredTestAsEmailAndTestAsPassword(string email, string password)
        {
            _digitalNetworksLoginPage.EnterCredentials(email, password);
        }

        [When(@"I press Log in")]
        public void WhenIPressLogIn()
        {
            _digitalNetworksLoginPage = _digitalNetworksLoginPage.ClickLogInButton();
        }        
        
        [Then(@"the alert message (.*) should be displayed")]
        public void ThenTheAlertMessageUserNameAndPasswordDoNotMatchShouldBeDisplayed(string expectedAlertMessage)
        {
            Assert.AreEqual(expectedAlertMessage, _digitalNetworksLoginPage.GetAlertMessage());
        }
    }
}
