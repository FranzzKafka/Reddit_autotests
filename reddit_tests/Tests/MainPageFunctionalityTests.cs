using System;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using reddit_tests.BaseTestsSetup;
using reddit_tests.PageObject;

namespace reddit_tests.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Main page funcionality tests")]
    public class MainPageFunctionalityTests : BaseTestSetup
	{
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(_driver);
            _driver.Url = "https://www.reddit.com/?feed=home";
        }

        [Test]
        [Description("Finding a specific community through the search field")]
        public void SearchCommunityTest()
        {
            _mainPage.FindInfoViaSearchField("Cat");

            string actualCommunityName = _mainPage.CommunityHeader.Text;

            string expectedCommunityName = "r/cat";

            Assert.That(actualCommunityName, Is.EqualTo(expectedCommunityName));
        }

        [Test]
        [Description("Posts filter opens a collection of posts on a specific topic")]
        public void PostsFilterTest()
        {
            int firstGameIndex = 1;

            _mainPage.ClickGameTopicsButton();

            string firstGameTopicName = _mainPage.GetGameTopicName(firstGameIndex);

            _mainPage.ClickGameTopic(firstGameIndex);

            string actualAboutPostsHeader = _mainPage.AboutPostsHeader.Text;

            string expectedAboutPostsHeader = "Posts about " + firstGameTopicName;

            Assert.That(actualAboutPostsHeader, Is.EqualTo(expectedAboutPostsHeader));
        }

        [Test]
        [Description("Popular posts filter shows posts with a rating above 999")]
        public void PopularPostsFilterTest()
        {
            _mainPage.ClickPopularPostsButton();

            int topPostRating = _mainPage.ConvertPostRatingToInt(_mainPage.TopPostRating.Text);

            int minimumPopularPostRating = 999;

            Assert.That(topPostRating, Is.AtLeast(minimumPopularPostRating));
        }

        [Test]
        [Description("Open User Agreement page through main page")]
        public void OpenUserAgremeentPageThroughMainPage()
        {
            _mainPage.ClickUserDropDown();

            _mainPage.ClickTermsAndPoliciesDropDown();

            var userAgremeentPage = _mainPage.ClickUserAgreementButton();

            string expectedDropDownText = "User Agreement";

            Assert.That(userAgremeentPage.ChooseDocumentDropDown.Text, Is.EqualTo(expectedDropDownText));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

