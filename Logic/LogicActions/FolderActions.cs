using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FolderActions
    {

        public static void AddInExistingFolder(IWebElement radioButton, SelectElement folder, IWebElement addButton, string folderName)
        {
            radioButton.Click();
            folder.SelectByText(folderName);
            addButton.Click();
        }
        public static void AddInNewFolder(IWebElement radioButton, IWebElement name, string folderName, IWebElement addButton)
        {
            radioButton.Click();
            name.SendKeys(folderName);
            addButton.Click();
        }
    }
}
