using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class LogIn
    {        
        private readonly IWebDriver driver;
    
        public LogIn(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public IWebElement UsernameBox => driver.FindElement(By.XPath("//input[contains(@id, 'txt_UserName')]"));

        public IWebElement PasswordBox => driver.FindElement(By.XPath("//input[contains(@id, 'txt_Password')]"));

        public IWebElement LoginButton => driver.FindElement(By.XPath("//input[contains(@id, 'LoginButton')]"));
    }
}
