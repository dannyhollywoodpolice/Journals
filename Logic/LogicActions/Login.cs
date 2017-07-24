using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Login
    {
        public static void LogIn(IWebElement usernameBox, IWebElement passwordBox, IWebElement loginButton, string username, string password)
        {
            usernameBox.SendKeys(username);
            passwordBox.SendKeys(password);
            loginButton.Click();
        }
        public static void Logout(IWebElement element)
        {
            element.Click();
        }
        public static void Clean(IWebElement usernameBox, IWebElement passwordBox)
        {
            usernameBox.Clear();
            passwordBox.Clear();
        }
    }
}
