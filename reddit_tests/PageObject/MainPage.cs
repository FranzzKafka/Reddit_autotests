using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace reddit_tests.PageObject
{
	public class MainPage
	{
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "_2BMnTatQ5gjKGK5OWROgaG")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "header-search-bar")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@type='submit']")]
        public IWebElement SearchSubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='_2torGbn_fNOMbGw3UAasPl iwmtpuJa21jtA4y_LuOVI']")]
        public IWebElement CommunityHeader { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='_3DRWid86ywqQiIYSK1e5mN icon icon-caret_down']")]
        public IWebElement GamesTopicsFilterHeader { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='yloKeyD8bfd8UJ_Gi9rsR']")]
        public IWebElement GameTopicsButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "_eYtD2XCVieq6emjKBH3m")]
        public IWebElement AboutPostsHeader { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='cq0sTeCPC4GI78UNPdClD icon icon-popular']")]
        public IWebElement PopularPostsButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='_1rZYMD_4xY3gRcSS3p8ODO _3a2ZHWaih05DgAOtvu6cIo ']")]
        public IWebElement TopPostRating { get; set; }

        public void FindInfoViaSearchField(string searchTopic)
        {
            SetTextToSearchField(searchTopic);
            SearchSubmitButtonClick();
        }

        public void SetTextToSearchField(string text)
        {
            SearchField.SendKeys(text);
        }

        public void SearchSubmitButtonClick()
        {
            SearchSubmitButton.Click();
        }

        public void ClickGameTopic(int topicIndex)
        {
            IList<IWebElement> allFilterTopics = _driver.FindElements(By.ClassName("yloKeyD8bfd8UJ_Gi9rsR"));

            allFilterTopics[topicIndex].Click();
        }

        public string GetGameTopicName(int topicIndex)
        {
            IList<IWebElement> allFilterTopics = _driver.FindElements(By.ClassName("yloKeyD8bfd8UJ_Gi9rsR"));

            return allFilterTopics[topicIndex].Text;
        }

        public void ClickGameTopicsButton()
        {
            GameTopicsButton.Click();
        }

        public void ClickPopularPostsButton()
        {
            PopularPostsButton.Click();
        }

        public int ConvertPostRatingToInt(string rating)
        {
            const int fractionAndLettersBeginIndex = 3;
            const int thousandthConverter = 1000;

            string convertableString = rating.Remove(rating.Length - fractionAndLettersBeginIndex);

            int ratingPoints = thousandthConverter * int.Parse(convertableString);

            return ratingPoints;
        }
    }
}

