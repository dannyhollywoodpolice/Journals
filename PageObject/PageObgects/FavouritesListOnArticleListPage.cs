using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    class FavouritesList
    {
        private readonly IWebDriver driver;
       

        public IList<IWebElement> Links => driver.FindElements(By.TagName("a"));

    }
}
