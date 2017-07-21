using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.PageObgects
{
    public class ArticleBodyPage : FoldersForm
    {
        private readonly IWebDriver driver;
       
        public ArticleBodyPage(IWebDriver browser) : base(browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public IWebElement favouritesLinkBody => driver.FindElement(By.PartialLinkText("Add to My Favorites"));
       
    }
}
