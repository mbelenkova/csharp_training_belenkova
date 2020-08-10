using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{

    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHepler navigationHepler;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager()
        {
            loginHelper = new LoginHelper(driver);
            navigationHepler = new NavigationHepler(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);

            driver = new FirefoxDriver();
            baseURL = "http://localhost";

           // verificationErrors = new StringBuilder();
            loginHelper = new LoginHelper(driver);
            navigationHepler = new NavigationHepler(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);

        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth
        {
            get { return loginHelper; }
        }
        public NavigationHepler Navigat
        {
            get { return navigationHepler; }
        }
        public GroupHelper GruopH
        {
            get { return groupHelper; }
        }
        public ContactHelper ContactH
        {
            get { return contactHelper; }

        }
    }
}
