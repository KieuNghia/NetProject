using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverIntroduction
{
    [TestClass]
    public class FacebookTest
    {
        private const string Login = "webdriver42@gmail.com";
        private const string Password = "test123dude";
        private const string UserName = "Andrew Appleseed";
        private IWebDriver _driver;

        [TestInitialize]
        public void TestInit()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("https://www.facebook.com/");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void facebookLoginTest()
        {
            InputLogin(Login);
            InputPassword(Password);
            ClickLogin();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            CheckUserName(UserName);

        }

        private void InputLogin(string login)
        {
            var emailField = _driver.FindElement(By.XPath("//input[@id = 'email']"));
            emailField.SendKeys(login);
        }


        private void InputPassword(string password)
        {
            var passwordField = _driver.FindElement(By.XPath("//input[@id = 'pass']"));
            passwordField.SendKeys(password);
        }

        private void CheckUserName(string userName)
        {
            var nameLink = _driver.FindElement(By.XPath("//a[@class  = 'fbxWelcomeBoxName']")).Text;
            Assert.IsTrue(nameLink.Contains(UserName), "User name doesn't match expected result");
        }

        private void ClickLogin()
        {
            var loginButton = _driver.FindElement(By.XPath("//input[@type = 'submit']"));
            loginButton.Click();

        }
    }
}
