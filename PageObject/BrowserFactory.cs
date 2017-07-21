using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObject
{
    public class BrowserFactory
    {
        private static readonly IDictionary<int, IWebDriver> Drivers = new Dictionary<int, IWebDriver>();
        private static IWebDriver driver;



        public static IWebDriver InitializeBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (!Drivers.ContainsKey(Thread.CurrentThread.ManagedThreadId))
                    {   
                        driver = new FirefoxDriver(); 
                        Drivers.Add(Thread.CurrentThread.ManagedThreadId, driver);
                    }
                    break;

                case "Chrome":
                    if (!Drivers.ContainsKey(Thread.CurrentThread.ManagedThreadId))
                    {
                        driver = new ChromeDriver();                          
                        Drivers.Add(Thread.CurrentThread.ManagedThreadId, driver);
                    }
                    break;
            }
            return Drivers[Thread.CurrentThread.ManagedThreadId];
        }       
    }
}

