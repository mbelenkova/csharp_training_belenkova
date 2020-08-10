using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{
    public class NavigationHepler: HelperBase
    {
       // private IWebDriver driver;
        private string baseURL;
        

        public NavigationHepler(IWebDriver driver,string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
         
        }

        public void OpenHomePage()
        {

            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {

            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToContactPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/edit.php");
        }
    }
}
