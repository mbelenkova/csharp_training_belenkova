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
       protected string baseURL;


        public NavigationHepler(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }


       public void OpenHomePage()
        {
            if (driver.Url ==baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            if((driver.Url== baseURL + "/group.php") && (IsElementPresent(By.Name("new"))))
            {
                return;
            
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToContactPage()
        {
            if ((driver.Url == baseURL + "/edit.php") && (IsElementPresent(By.Name("add"))))
          {
              return;
          }

            driver.Navigate().GoToUrl(baseURL + "/edit.php");
        }

      /*  public void OpenContactDetailsPage(int index)
        {
            if (driver.Url == baseURL + "/view.php") 
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/view.php");

        }
       */

    }
}
