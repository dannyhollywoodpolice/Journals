using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.PageObgects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class ArticleList : FoldersForm
    {
        private readonly IWebDriver driver;
       
        public ArticleList(IWebDriver browser) : base(browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public IList<IWebElement> favouritesLinkList => driver.FindElements(By.PartialLinkText("+ Favorites"));

        public IWebElement SpecialArticle(IWebDriver driver, string articleName)
        {
            IWebElement article = driver.FindElement(By.LinkText(articleName));
            return article;
        }
      }
}
