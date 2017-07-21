using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.PageObgects
{
    public class PlasticAndReconstructiveSurgeryPage
    {
        private readonly IWebDriver driver;
       
        public PlasticAndReconstructiveSurgeryPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }
        public IList<IWebElement> FoundWords(string word)
        {
            IList<IWebElement> listOfDisplayedWords = driver.FindElements(By.XPath("//*[contains(text(),'"+word+"')]"));
            return listOfDisplayedWords;
        }
        public IList<IWebElement> FoundArticles()
        {
            IList<IWebElement> listOfArticles = driver.FindElements(By.TagName("article"));
            return listOfArticles;
        }
       
       public string TrickyNumberOfArticles => driver.FindElement(By.XPath("//div[contains(@id, 'd23b2_ctl00_results')]")).Text.ToString();        
        
        public IWebElement SearchBox => driver.FindElement(By.XPath("//input[contains(@id, '_SearchBox_txtKeywords')]"));

        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[contains(@id, 'btnGlobalSearchMagnifier')]"));

        public IWebElement NextLink => driver.FindElement(By.XPath("//a[contains(@id, '_ctl00_listItemActionToolbarControlBottom_pagingControl_nextLink')]"));

        public IList<IWebElement> PageButton(string numberOfPage)
        {
            IList<IWebElement> buttons = driver.FindElements(By.LinkText(numberOfPage));
            return buttons;
        }
        public IWebElement Article(string name)
        {
            IWebElement articleLink = driver.FindElement(By.LinkText(name));
            return articleLink;
        }
        public IWebElement SaveSearchButton => driver.FindElement(By.XPath("//input[contains(@class, 'primary-button')]"));

        public IWebElement SearchNametextBox => driver.FindElement(By.XPath("//input[contains(@id, '_ctl00_searchFacetsControl_saveSearchPopup_txtSaveSearchName')]"));

        public IWebElement SaveSearchButtonForm => driver.FindElement(By.XPath("//input[contains(@id, 'ctl00_ctl45_g_8634027f_7ffc_40cc_af01_358c6b8d23b2_ctl00_searchFacetsControl_saveSearchPopup_saveSearch')]"));
    }
}
