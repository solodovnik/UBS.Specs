using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UBS.Automation
{
    public class BrowserFactory
    {
        public static IWebDriver InitBrowser(string browserName)
        {
            IWebDriver driver;

            switch (browserName)
            {
                case "Chrome":
                    {
                        ChromeOptions chromeOption = new ChromeOptions();

                        chromeOption.AddArguments("--disable-extensions");
                        driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOption);
                        break;
                    }

                default:
                    {
                        throw new Exception("Not supported browser");
                    }
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
