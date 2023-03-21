using System;
using reddit_tests.BaseTestsSetup;
using reddit_tests.DataGenerator;
using reddit_tests.PageObject;

namespace reddit_tests.Tests
{
	public class RegistrationTests : BaseTestSetup
	{
        private RegistrationDataGenerator _generator = new RegistrationDataGenerator();
        private RegistrationPage _registrationPage;

        [SetUp]
        public void SetUp()
        {
            _registrationPage = new RegistrationPage(_driver);
            _driver.Url = "https://www.reddit.com/account/register/?dest=https%3A%2F%2Fwww.reddit.com%2F";
        }

        [Test]
        [Description("Register new user")]
        public void RegisterNewUserTest()
        {
            _registrationPage.SetTextToEmailFiled(_generator.GenerateRandomEmail());

            _registrationPage.ClicklContinueRegistrationButton();

            _registrationPage.SetTextToUserNameField(_generator.GenerateRandomUserName());

            _registrationPage.SetTextToPasswordField(_generator.GenerateRandomPassword());

            _registrationPage.CliclConfirmRegistrationButton();

            Assert.That(_registrationPage.AboutYouSurveyHeader.Displayed, Is.EqualTo(true));
        }

        [Test]
        [Description("Click on suggested username place it into username text field")]
        public void ChooseUserNameSuggestionTest()
        {
            const int firstUserNameSuggestionIndex = 0;

            _registrationPage.ClicklContinueRegistrationButton();

            string firstUserNameSuggestion = _registrationPage.GetUserNameSuggestion(firstUserNameSuggestionIndex);

            _registrationPage.SuggestedUserNameClick(firstUserNameSuggestionIndex);

            string textInsideUserNameTextField = _registrationPage.UserNameTextField.Text;

            Assert.That(firstUserNameSuggestion, Is.EqualTo(textInsideUserNameTextField));
        }

        [Test]
        [Description("After click on update button new user name suggestions appears")]
        public void UpdateUserNameSuggestionsTest()
        {
            const int firstUserNameSuggestionIndex = 0;

            _registrationPage.ClicklContinueRegistrationButton();

            string firstUserNameSuggestionOld = _registrationPage.GetUserNameSuggestion(firstUserNameSuggestionIndex);

            _registrationPage.ClickUserNameSuggestionsUpdateButton();

            string firstUserNameSuggestionNew = _registrationPage.GetUserNameSuggestion(firstUserNameSuggestionIndex);

            Assert.That(firstUserNameSuggestionNew, Is.Not.EqualTo(firstUserNameSuggestionOld));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

