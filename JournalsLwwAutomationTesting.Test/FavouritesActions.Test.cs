using Logic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObject;
using PageObject.PageObgects;
using System;
using System.Configuration;
using System.Linq;

namespace JournalsLwwAutomationTesting.Test
{

    [TestFixture]
    [Parallelizable]
    class FavouritesTest
    {
        static string USERNAME = ConfigurationSettings.AppSettings["USERNAME"];
        static string PASSWORD = ConfigurationSettings.AppSettings["PASSWORD"];
        static string NEWFOLDER = ConfigurationSettings.AppSettings["NEWFOLDER"];
        static string NEWFOLDER1 = ConfigurationSettings.AppSettings["NEWFOLDER1"];
        static string EXISTINGFOLDER = ConfigurationSettings.AppSettings["EXISTINGFOLDER"];
        static string mainPage = ConfigurationSettings.AppSettings["mainPage"];
        static string journalUrl = ConfigurationSettings.AppSettings["journalUrl"];
        static string articlename = ConfigurationSettings.AppSettings["articlename"];
        static string articleUrl = ConfigurationSettings.AppSettings["articleUrl"];
        static string favouritesPageUrl = ConfigurationSettings.AppSettings["favouritesPageUrl"];
        static private IWebDriver driver;

        [TestFixtureSetUp]
        public static void LogInSetUp()
        {
            
            driver = BrowserFactory.InitializeBrowser("Chrome");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Navigation.Navigate(driver, "http://journals.lww.com/pages/login.aspx?ContextUrl=%2fpages%2fdefault.aspx");

            LogIn loginPage = new LogIn(driver);
            User user = new User();

            user.Username = USERNAME;
            user.Password = PASSWORD;
            //log in the web site
            Login.LogIn(loginPage.UsernameBox, loginPage.PasswordBox, loginPage.LoginButton, user.Username, user.Password);
        }

        [TestFixtureTearDown]
        public static void TearDown()
        {
            Navigation.Navigate(driver, favouritesPageUrl);
            FavouritesPage favouritesPage = new FavouritesPage(driver);
            if (favouritesPage.FolderLink(NEWFOLDER).Displayed == true)
            {
                favouritesPage.FolderLink(NEWFOLDER).Click();
                FavouritesActions.DeleteFolder(favouritesPage.deleteLink, favouritesPage.deleteButton);
            }
            Navigation.Navigate(driver, favouritesPageUrl);
            if (favouritesPage.FolderLink(NEWFOLDER1).Displayed == true)
            {
                favouritesPage.FolderLink(NEWFOLDER).Click();
                FavouritesActions.DeleteFolder(favouritesPage.deleteLink, favouritesPage.deleteButton);
            }
            Navigation.Navigate(driver, mainPage);
            driver.Close();
        }
      
        [Test]
        public void AddToExistingFromList()
        {
            ArticleList articles = new ArticleList(driver);
            FavouritesPage favouritesPage = new FavouritesPage(driver);

            //go to journal
            Navigation.Navigate(driver, journalUrl);
            //choose an article to add in folder     
            var LinksList = articles.favouritesLinkList;
            ArticleListActions.ClickFavFromList(LinksList.ElementAt(0));
            //select an existing folder
            IWebElement selectedFolder = articles.ExistingFolderList;
            var selectElement = new SelectElement(selectedFolder);
            //add article in existing folder
            FolderActions.AddInExistingFolder(articles.ExistingFolderRadioButton, selectElement, articles.AddButton, EXISTINGFOLDER);
            articles.GoToFavouritesListButton.Click();
            //check if article is in folder
            Assert.IsTrue(favouritesPage.ElementInFavourites(articlename).Displayed);         
        }
        [Test]
        public void AddToNewFromList()
        {
            ArticleList articles = new ArticleList(driver);
            FavouritesPage favouritesPage = new FavouritesPage(driver);

            //go to journal
            Navigation.Navigate(driver, journalUrl);
            //choose an article to add in folder            
            var LinksList = articles.favouritesLinkList;
            ArticleListActions.ClickFavFromList(LinksList.ElementAt(0));
            //add article in new folder
            FolderActions.AddInNewFolder(articles.NewFolderRadioButton, articles.FolderTextBox, NEWFOLDER1, articles.AddButton);
            //check if an article is in folder
            articles.GoToFavouritesListButton.Click();
            if (favouritesPage.FolderLink(NEWFOLDER1).Displayed == true)
            {
                favouritesPage.FolderLink(NEWFOLDER1).Click();
            }
            Assert.IsTrue(favouritesPage.ElementInFavourites(articlename).Displayed);
        }
        [Test]
        public void AddToNewFromBody()
        {
            ArticleBodyPage article = new ArticleBodyPage(driver);
            FavouritesPage favouritesPage = new FavouritesPage(driver);
            //go to the article            
            Navigation.Navigate(driver, articleUrl);
            //add article in new folder
            article.favouritesLinkBody.Click();
            FolderActions.AddInNewFolder(article.NewFolderRadioButton, article.FolderTextBox, NEWFOLDER, article.AddButton);
            article.GoToFavouritesListButton.Click();
            //check if the article is in folder
            if (favouritesPage.FolderLink(NEWFOLDER).Displayed == true)
            {
                favouritesPage.FolderLink(NEWFOLDER).Click();
            }
            Assert.IsTrue(favouritesPage.ElementInFavourites(articlename).Displayed);
        }
        [Test]
        public void AddToExistingFromBody()
        {
            ArticleBodyPage article = new ArticleBodyPage(driver);
            FavouritesPage favouritesPage = new FavouritesPage(driver);
            //go to the article  
            Navigation.Navigate(driver, articleUrl);
            //select an existing folder
            IWebElement selectedFolder = article.ExistingFolderList;
            var selectElement = new SelectElement(selectedFolder);
            //add article in existing folder
            article.favouritesLinkBody.Click();
            FolderActions.AddInExistingFolder(article.ExistingFolderRadioButton, selectElement, article.AddButton, EXISTINGFOLDER);
            article.GoToFavouritesListButton.Click();
            Assert.IsTrue(favouritesPage.ElementInFavourites(articlename).Displayed);
        }
    }
}
