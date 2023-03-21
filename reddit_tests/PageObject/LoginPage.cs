using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace reddit_tests.PageObject
{
	public class LoginPage
	{
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "loginUsername")]
        public IWebElement UserNameTextField { get; set; }

        [FindsBy(How = How.Id, Using = "loginPassword")]
        public IWebElement PasswordTextField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@type='submit']")]
        public IWebElement SubmitLoginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "AnimatedForm__errorMessage")]
        public IWebElement ErrorLoginMessage { get; set; }

        public void SetTextToUserNameField(string userName)
        {
            UserNameTextField.SendKeys(userName);
        }

        public void SetTextToPasswrodField(string password)
        {
            PasswordTextField.SendKeys(password);
        }

        public MainPage ClickSubmitLoginButton()
        {
            SubmitLoginButton.Click();
            return new MainPage(_driver);
        }
    }
}

