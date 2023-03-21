using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace reddit_tests.PageObject
{
	public class RegistrationPage
	{
        private IWebDriver _driver;

        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "regEmail")]
        public IWebElement EmailTextField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@type='submit']")]
        public IWebElement ContinueRegistrationButton { get; set; }

        [FindsBy(How = How.Id, Using = "regUsername")]
        public IWebElement UserNameTextField { get; set; }

        [FindsBy(How = How.Id, Using = "regPassword")]
        public IWebElement PasswordTextField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@data-step='username-and-password']")]
        public IWebElement ConfirmRegistrationButton { get; set; }

        [FindsBy(How = How.Id, Using = "_2RClZCR0YjGTPowbzG7r82")]
        public IWebElement AboutYouSurveyHeader { get; set; }

        [FindsBy(How = How.ClassName, Using = "Onboarding__usernameRefresh")]
        public IWebElement UserNameSuggestionsUpdateButton { get; set; }

        public void SetTextToEmailFiled(string email)
        {
            EmailTextField.SendKeys(email);
        }

        public void ClicklContinueRegistrationButton()
        {
            ContinueRegistrationButton.Click();
        }

        public void SetTextToUserNameField(string userName)
        {
            UserNameTextField.SendKeys(userName);
        }

        public void SetTextToPasswordField(string password)
        {
            PasswordTextField.SendKeys(password);
        }

        public void CliclConfirmRegistrationButton()
        {
            ConfirmRegistrationButton.Click();
        }

        public string GetUserNameSuggestion(int userNameIndex)
        {
            IList<string> allSuggestions = new List<string>();

            foreach (var element in _driver.FindElements(By.ClassName("Onboarding__usernameSuggestion")))
            {
                allSuggestions.Add(element.Text);
            }

            return allSuggestions[userNameIndex];
        }

        public void SuggestedUserNameClick(int userNameIndex)
        {
            IList<IWebElement> allSuggestions = new List<IWebElement>();
            allSuggestions = _driver.FindElements(By.ClassName("Onboarding__usernameSuggestion"));
            allSuggestions[userNameIndex].Click();
        }

        public void ClickUserNameSuggestionsUpdateButton()
        {
            UserNameSuggestionsUpdateButton.Click();
        }
    }
}

