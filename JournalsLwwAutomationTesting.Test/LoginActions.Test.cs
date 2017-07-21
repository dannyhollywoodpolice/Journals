using NUnit.Framework;
using OpenQA.Selenium;
using PageObject;
using System;
using System.Configuration;

namespace JournalsLwwAutomationTesting.Test
{
    
    [TestFixture]
   [Parallelizable]
    public class LoginTest
    {
        static string USERNAME = ConfigurationSettings.AppSettings["USERNAME"];
        static string PASSWORD = ConfigurationSettings.AppSettings["PASSWORD"];
        static string uncorrectUsername = ConfigurationSettings.AppSettings["uncorrectUsername"];
        static string uncorrectPassword = ConfigurationSettings.AppSettings["uncorrectPassword"];
        static string emptyUsername = ConfigurationSettings.AppSettings["emptyUsername"];
        static string emptyPassword = ConfigurationSettings.AppSettings["emptyPassword"];
        static private IWebDriver driver;
       
        [TestFixtureSetUp]
        public static void LogInSetUp()
        {                    
            driver = BrowserFactory.InitializeBrowser("Chrome");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
        [SetUp]
        public void OpenLoginPage()
        {
            driver.Manage().Window.Maximize();
            Navigation.Navigate(driver, "http://journals.lww.com/pages/login.aspx?ContextUrl=%2fpages%2fdefault.aspx");
            LogIn loginPage = new LogIn(driver);
            Login.Clean(loginPage.UsernameBox, loginPage.PasswordBox);
        }

        [TestFixtureTearDown]
        public static void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void OpenLoginPageCorrectUserdata()
        {
            LogIn loginPage = new LogIn(driver);
            User user = new User();
            Header header = new Header(driver);

            user.Username = USERNAME;
            user.Password = PASSWORD;

            Login.LogIn(loginPage.UsernameBox, loginPage.PasswordBox, loginPage.LoginButton, user.Username, user.Password);
           Assert.AreEqual(driver.Url, "http://journals.lww.com/pages/default.aspx");           
           header.Logout.Click();
        }

        [Test]
        public void OpenLoginPageUncorrectUserdata()
        {
            User user = new User();
            LogIn loginPage = new LogIn(driver);

            user.Username = uncorrectUsername;
            user.Password = uncorrectPassword;

            Login.LogIn(loginPage.UsernameBox, loginPage.PasswordBox, loginPage.LoginButton, user.Username, user.Password);
            IWebElement element = driver.FindElement(By.ClassName("ej-error-message-icon"));
            Assert.IsNotNull(element);

        }

        [Test]
        public void OpenLoginPageEmptyPassword()
        {
            User user = new User();
            LogIn loginPage = new LogIn(driver);

            user.Username = USERNAME;
            user.Password = emptyPassword;
            
            Login.LogIn(loginPage.UsernameBox, loginPage.PasswordBox, loginPage.LoginButton, user.Username, user.Password);
            IWebElement element = driver.FindElement(By.ClassName("login-error-message"));
            Assert.IsNotNull(element);
        }

        [Test]
        public void OpenLoginPageEmptyUsername()
        {
            User user = new User();
            LogIn loginPage = new LogIn(driver);

            user.Username = emptyUsername;
            user.Password = PASSWORD;
           
            Login.LogIn(loginPage.UsernameBox, loginPage.PasswordBox, loginPage.LoginButton, user.Username, user.Password);
            IWebElement element = driver.FindElement(By.ClassName("login-error-message"));
            Assert.IsNotNull(element);
        }
    }
}
