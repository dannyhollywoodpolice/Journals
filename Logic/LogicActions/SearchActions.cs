using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SearchActions
    {
        public static void SearchForWord(IWebElement searchBox, IWebElement searchButton, string word)
        {
            searchBox.SendKeys(word);
            searchButton.Click();
        }
        public static int GetNumberOfArticles(string textOfElement)
        {
            String[] trickyArray = textOfElement.Split(' ');
            int number = Int32.Parse(trickyArray.ElementAt(0));
            return number;
        }
        public static void SaveSearch(IWebElement saveButton, IWebElement textBox, IWebElement saveButtonSmall, string searchName)
        {
            saveButton.Click();
            textBox.SendKeys(searchName);
            saveButtonSmall.Click();
        }
    }
}
