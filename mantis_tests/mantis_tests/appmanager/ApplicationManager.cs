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
using NUnit.Framework;

namespace mantis_tests
{

    public class ApplicationManager
    {
       
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected ManagementMenuHelper managementMenuHelper;
        protected ProjectManagementHelper projectManagementHelper;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            

            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
           // verificationErrors = new StringBuilder();
            loginHelper = new LoginHelper(this);
            managementMenuHelper = new ManagementMenuHelper(this);

            projectManagementHelper = new ProjectManagementHelper(this);

          //  navigationHepler = new NavigationHepler(this,baseURL);
          //  groupHelper = new GroupHelper(this);
          //  contactHelper = new ContactHelper(this);


          
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
                newInstance.driver.Url = "http://localhost/mantisbt-2.24.3/login_page.php";
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

        public ManagementMenuHelper Navigat
        {
            get { return managementMenuHelper; }
        }

        public ProjectManagementHelper prManH
        {
            get { return projectManagementHelper; }

        }

    }
}
