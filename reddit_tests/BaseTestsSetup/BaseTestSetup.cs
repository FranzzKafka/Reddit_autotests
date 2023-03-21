using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace reddit_tests.BaseTestsSetup
{
	public class BaseTestSetup
	{
        protected IWebDriver _driver;
        protected const int ImplicitWaitingTimeMs = 5000;

        [SetUp]
        public void BaseSetup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(ImplicitWaitingTimeMs);
        }
    }
}

