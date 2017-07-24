using Logic;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject;
using PageObject.PageObgects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace JournalsLwwAutomationTesting.Test
{
    [TestFixture]
   [Parallelizable]
    public class Search
    {
        static string USERNAME = ConfigurationSettings.AppSettings["USERNAME"];
        static string PASSWORD = ConfigurationSettings.AppSettings["PASSWORD"];
        static string plasticSurgeryJournalUrl = ConfigurationSettings.AppSettings["plasticSurgeryJournalUrl"];
        static string searchWord = ConfigurationSettings.AppSettings["searchWord"];
        static string articleName = ConfigurationSettings.AppSettings["articleName"];
        static string numOfPage = ConfigurationSettings.AppSettings["numOfPage"];
        static string constArticleName = ConfigurationSettings.AppSettings["constArticleName"];
        static string constSearchName = ConfigurationSettings.AppSettings["constSearchName"];
        static string searchName = ConfigurationSettings.AppSettings["searchName"];
        static string searchFolder = ConfigurationSettings.AppSettings["searchFolder"];
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
            favouritesPage.ElementInFavourites("Saved Searches").Click();
            if (favouritesPage.deleteSearchLink.Displayed)
            {
                favouritesPage.deleteSearchLink.Click();
                favouritesPage.deleteSearchButton.Click();
            }
            Navigation.Navigate(driver, plasticSurgeryJournalUrl);
            Header header = new Header(driver);
            header.Logout.Click();
            driver.Close();
        }
        [SetUp]
        public void Navigate()
        {
            Navigation.Navigate(driver, plasticSurgeryJournalUrl);           
        }
        [Test]
        public void SearchForAGivenWordResultsAreNotEmpty()
        {           
            PlasticAndReconstructiveSurgeryPage surgeryPage = new PlasticAndReconstructiveSurgeryPage(driver);

            SearchActions.SearchForWord(surgeryPage.SearchBox, surgeryPage.SearchButton, searchWord);

            IList<IWebElement> listOfWords = surgeryPage.FoundWords(searchWord);

            Assert.True(listOfWords.Count()>0);
        }
        [Test]
        public void SearchForAGivenWordNumberOfArticlesOnPage()
        {
            PlasticAndReconstructiveSurgeryPage surgeryPage = new PlasticAndReconstructiveSurgeryPage(driver);

            SearchActions.SearchForWord(surgeryPage.SearchBox, surgeryPage.SearchButton, searchWord);

            IList<IWebElement> listOfArticles = surgeryPage.FoundArticles();

            Assert.AreEqual(60, listOfArticles.Count());
        }
        [Test]
        public void TrickySearchForAGivenWordAllNumberOfArticles()
        {
            PlasticAndReconstructiveSurgeryPage surgeryPage = new PlasticAndReconstructiveSurgeryPage(driver);

            SearchActions.SearchForWord(surgeryPage.SearchBox, surgeryPage.SearchButton, searchWord);

            int trickyNum = SearchActions.GetNumberOfArticles(surgeryPage.TrickyNumberOfArticles);
           
            Assert.True(trickyNum>100);
        }
        [Test]
        public void SearchForAGivenNumberOfArticlesOnSpecialPage()
        {
            PlasticAndReconstructiveSurgeryPage surgeryPage = new PlasticAndReconstructiveSurgeryPage(driver);

            SearchActions.SearchForWord(surgeryPage.SearchBox, surgeryPage.SearchButton, searchWord);

            var buttons = surgeryPage.PageButton(numOfPage);
            while (buttons.Count() == 0)
            {
                surgeryPage.NextLink.Click();
                buttons = surgeryPage.PageButton(numOfPage);
            }
            surgeryPage.PageButton(numOfPage).ElementAt(0).Click();
            Assert.AreEqual(60, surgeryPage.FoundArticles().Count());
        }
        [Test]
        public void SearchForAGivenArticleName()
        {
            PlasticAndReconstructiveSurgeryPage surgeryPage = new PlasticAndReconstructiveSurgeryPage(driver);

            SearchActions.SearchForWord(surgeryPage.SearchBox, surgeryPage.SearchButton, articleName);

            Assert.IsTrue(surgeryPage.Article(articleName).Displayed);
        }
        [Test]
        public void VerifyIfSearchSaved()
        {
            PlasticAndReconstructiveSurgeryPage surgeryPage = new PlasticAndReconstructiveSurgeryPage(driver);
            FavouritesPage favouritesPage = new FavouritesPage(driver);

            SearchActions.SearchForWord(surgeryPage.SearchBox, surgeryPage.SearchButton, articleName);            
            SearchActions.SaveSearch(surgeryPage.SaveSearchButton, surgeryPage.SearchNametextBox, surgeryPage.SaveSearchButtonForm, searchName);
            Navigation.Navigate(driver, favouritesPageUrl);           
            favouritesPage.ElementInFavourites("Saved Searches").Click();
            
            Assert.IsTrue(favouritesPage.ElementInFavourites(searchName).Displayed);           
        }
        [Test]
        public void VerifyIfSearchCorrect()
        {
            PlasticAndReconstructiveSurgeryPage surgeryPage = new PlasticAndReconstructiveSurgeryPage(driver);
            SearchActions.SearchForWord(surgeryPage.SearchBox, surgeryPage.SearchButton, constArticleName);
            SearchActions.SaveSearch(surgeryPage.SaveSearchButton, surgeryPage.SearchNametextBox, surgeryPage.SaveSearchButtonForm, constSearchName);

            FavouritesPage favouritesPage = new FavouritesPage(driver);

            Navigation.Navigate(driver, favouritesPageUrl);
            favouritesPage.ElementInFavourites(searchFolder).Click();
            favouritesPage.ElementInFavourites(constSearchName).Click();            

            Assert.IsTrue(surgeryPage.Article(constArticleName).Displayed);

        }
    }
}
