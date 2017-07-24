using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ArticleListActions
    {

        public static void ClickFavFromList(IWebElement addLink)
        {
            addLink.Click();
        }
    }
}
