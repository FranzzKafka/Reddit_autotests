using System;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using reddit_tests.BaseTestsSetup;
using reddit_tests.PageObject;

namespace reddit_tests.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Login tests")]
    public class LoginTests : BaseTestSetup
	{
        private LoginPage _loginPage;

        [SetUp]
        public void SetUp()
        {
            _loginPage = new LoginPage(_driver);
            _driver.Url = "https://www.reddit.com/account/login/?experiment_d2x_2020ify_buttons=enabled&experiment_d2x_google_sso_gis_parity=enabled&experiment_d2x_" +
                "onboarding=enabled&experiment_d2x_safari_onetap=enabled&experiment_d2x_am_modal_design_update=enabled";
        }

        [Test]
        [Description("Login test")]
        public void LogitTest()
        {
            _loginPage.SetTextToUserNameField("Significant_Art2933");

            _loginPage.SetTextToPasswrodField("Bmasm123s");

            var _mainPage = _loginPage.ClickSubmitLoginButton();

            Assert.That(_mainPage.UserName.Displayed, Is.EqualTo(true));
        }

        [TestCase("wrongUserName1", "Bmasm123s")]
        [TestCase("Significant_Art2933", "WrongPassword1")]
        [Description("Login with wrong username/passwordd")]
        public void LoginWithWrongDataTest(string userName, string password)
        {
            const int errorMessageAppearingTimeMs = 3000;

            _loginPage.SetTextToUserNameField(userName);

            _loginPage.SetTextToPasswrodField(password);

            _loginPage.ClickSubmitLoginButton();

            Thread.Sleep(errorMessageAppearingTimeMs);

            Assert.That(_loginPage.ErrorLoginMessage.Displayed, Is.EqualTo(true));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

