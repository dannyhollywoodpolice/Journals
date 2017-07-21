using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.PageObgects
{
    public class FoldersForm
    {
        private readonly IWebDriver driver;
   
        public FoldersForm(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }
        public IWebElement NewFolderRadioButton => driver.FindElement(By.XPath("//input[contains(@id, '_rdoNewCollection')]"));

        public IWebElement ExistingFolderRadioButton => driver.FindElement(By.XPath("//input[contains(@id, '_rdoExistingCollection')]"));

        public IWebElement ExistingFolderList => driver.FindElement(By.TagName("select"));
      
        public IWebElement FolderTextBox => driver.FindElement(By.XPath("//input[contains(@id, 'txtCollectionName')]"));

        public IWebElement DescriptionTextBox => driver.FindElement(By.XPath("//textarea[contains(@id, 'txtDescription')]"));

        public IWebElement AddButton => driver.FindElement(By.XPath("//input[contains(@id, 'btnAddArticle')]"));

        public IWebElement CancelButton => driver.FindElement(By.XPath("//input[contains(@id, 'btnCancelAddToMyCollections')]"));

        public IWebElement GoToFavouritesListButton => driver.FindElement(By.XPath("//input[contains(@id, '_btnAddToMyCollection')]"));
                                                                                                        
        public IWebElement CloseGoToFavouriteBoxButton => driver.FindElement(By.XPath("//input[contains(@id, 'ctl00_ctl45_g_2d6a7e51_ed38_496a_b135_90c69b2276fb_ctl00_addToMyCollections_btnCancelAddToMyCollectionsMessage')]"));

        public IWebElement CloseGoToFavouriteBoxCross => driver.FindElement(By.XPath("//input[contains(@id, 'ctl00_ctl45_g_2d6a7e51_ed38_496a_b135_90c69b2276fb_ctl00_addToMyCollections_closeWindowMessage')]"));
    }
}
