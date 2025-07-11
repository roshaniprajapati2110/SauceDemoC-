using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceLabTestFramework.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void EnterUsername(string username)
        {
            var usernameField = driver.FindElement(By.Id("user-name"));
            usernameField.Clear();
            usernameField.SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            var passwordField = driver.FindElement(By.Id("password"));
            passwordField.Clear();
            passwordField.SendKeys(password);
        }
        public void ClickLoginButton()
        {
            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();
        }
    }
}
