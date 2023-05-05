using System;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using reddit_tests.BaseTestsSetup;
using reddit_tests.PageObject;

namespace reddit_tests.Tests
{
	[TestFixture]
    [AllureNUnit]
    [AllureSuite("User Agremeent page functionality tests")]
    public class UserAgremeentPageFuncionalityTests : BaseTestSetup
	{
        private UserAgremeentPage _userAgremeentPage;

        [SetUp]
        public void SetUp()
        {
            _userAgremeentPage = new (_driver);
            _driver.Url = "https://www.redditinc.com/policies/user-agreement-april-18-2023";
        }

        [Test]
        [Description("Change user agremeent revision")]
        public void ChangeUserAgremeentRevisionTest()
        {
            _userAgremeentPage.ClickRevisionsDropDown();

            _userAgremeentPage.ClickLatestServiceAgremeentRevisionButton();

            string expectedUserAgremeentHeaderText = "Effective March 21, 2018.";

            Assert.That(_userAgremeentPage.UserAgremeentSubHeader.Text, Is.EqualTo(expectedUserAgremeentHeaderText));
        }

        [Test]
        [Description("Change User Agremeent language")]
        public void ChangeUserAgremeentLanguageTest()
        {
            int changeLanguageDropDownIndex = 1;

            _userAgremeentPage.ClickSpecificDropDown(changeLanguageDropDownIndex);

            _userAgremeentPage.ClickDutchLanguageButton();

            string expectedServiceAgremeentSubheaderText = "Met ingang van 19 juni 2023. Laatst herzien 18 april 2023";

            Assert.That(_userAgremeentPage.UserAgremeentSubHeader.Text, Is.EqualTo(expectedServiceAgremeentSubheaderText));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

