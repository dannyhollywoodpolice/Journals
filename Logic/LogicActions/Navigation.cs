using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Navigation
    {
        public static void Navigate(IWebDriver driver, string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
