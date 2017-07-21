using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.PageObgects
{
    public class FavouritesPage : FoldersForm
    {
        private readonly IWebDriver driver;
     
        public FavouritesPage(IWebDriver browser) : base(browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }
        public IWebElement ElementInFavourites(string articleName)
        {
            IWebElement articleLink = driver.FindElement(By.PartialLinkText(articleName));
            return articleLink;
        }
        public IWebElement FolderLink(string folderName)
        {
            IWebElement folderLink = driver.FindElement(By.PartialLinkText(folderName));
            return folderLink;
        }        
        public IWebElement deleteLink => driver.FindElement(By.XPath("//a[contains(@id, '_ctl00_lnkDeleteMyCollection')]"));

        public IWebElement deleteButton => driver.FindElement(By.XPath("//input[contains(@id, 'ctl00_deleteMyCollectionControl_btnDelete')]"));

        public IWebElement Folder(string folderName)
        {
            IWebElement folder = driver.FindElement(By.Name(folderName));
            return folder;

        }
        public IWebElement deleteSearchLink => driver.FindElement(By.XPath("//a[contains(@id, '_4b09_93c6_0c4b591a4a83_ctl00_ctl00_SavedSearchesWebGrid_ci_0_2_0_lnkDeleteItem')]"));

        public IWebElement deleteSearchButton => driver.FindElement(By.XPath("//input[contains(@id, '_ctl00_ucDeleteSavedSearchItem_btnDelete')]"));
    }

}
