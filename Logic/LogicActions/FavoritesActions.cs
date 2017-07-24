using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FavouritesActions
    {

        public static void DeleteFolder(IWebElement deleteLink, IWebElement deleteButton)
        {
            deleteLink.Click();
            deleteButton.Click();
        }
    }
}
