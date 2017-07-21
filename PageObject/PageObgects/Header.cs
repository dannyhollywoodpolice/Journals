using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class Header
    {
        private readonly IWebDriver driver;
      
        public Header(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public IWebElement Login => driver.FindElement(By.XPath("//a[contains(@id, 'lnkLogin')]"));

        public IWebElement Logout => driver.FindElement(By.XPath("//a[contains(@id, 'ucUserActionsToolbar_lnkLogout')]"));
        
        public IWebElement Account => driver.FindElement(By.XPath("//span[contains(@id, 'lblAccount')]"));

        public IWebElement FavouritesSpan => driver.FindElement(By.XPath("//span[text()='Favorites']"));
    }
}
