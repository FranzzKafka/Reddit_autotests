using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace reddit_tests.PageObject
{
	public class UserAgremeentPage
	{
        private IWebDriver _driver;

        public UserAgremeentPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@class='jcf-select jcf-unselectable jcf-select-filter-options']")]
        public IWebElement ChooseDocumentDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='jcf-select jcf-unselectable jcf-select-revisions']")]
        public IWebElement RevisionsDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@data-index='6']")]
        public IWebElement LatestServiceAgremeentRevisionButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "large-text")]
        public IWebElement UserAgremeentSubHeader { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[text()='English (US)']")]
        public IWebElement UserAgremeentLanguageDropDown { get; set; }

        [FindsBy(How = How.ClassName, Using = "jcf-option")]
        public IWebElement DutchLanguageButton { get; set; }

        public void ClickRevisionsDropDown()
        {
            RevisionsDropDown.Click();
        }

        public void ClickLatestServiceAgremeentRevisionButton()
        {
            LatestServiceAgremeentRevisionButton.Click();
        }

        public void ClickUserAgremeentLanguageDropDown()
        {
            UserAgremeentLanguageDropDown.Click();
        }

        public void ClickDutchLanguageButton()
        {
            DutchLanguageButton.Click();
        }

        public void ClickSpecificDropDown(int dropDownIndex)
        {
            IList<IWebElement> allDropDowns = new List<IWebElement>();
            allDropDowns = _driver.FindElements(By.XPath(".//*[@class='jcf-select jcf-unselectable jcf-select-filter-options']"));
            allDropDowns[dropDownIndex].Click();
        }
    }
}

