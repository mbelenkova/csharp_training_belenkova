using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            //loginHelper = new LoginHelper(driver);
           // navigationHepler = new NavigationHepler(driver, baseURL);
           // groupHelper = new GroupHelper(driver);
           // contactHelper = new ContactHelper(driver);

            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            baseURL = "http://localhost";

           // verificationErrors = new StringBuilder();
            loginHelper = new LoginHelper(this);
            navigationHepler = new NavigationHepler(this,baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);


          
        }

         ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if(!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigat.OpenHomePage();
                app.Value = newInstance;
                
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get { return driver; }

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
