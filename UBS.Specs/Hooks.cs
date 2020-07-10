using BoDi;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;
using UBS.Automation;

namespace UBS.Specs
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = BrowserFactory.InitBrowser(ConfigurationManager.AppSettings["browser"]);
            _objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            driver.Quit();
        }
    }
}
