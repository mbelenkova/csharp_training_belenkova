using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{
    
    public class HelperBase
    {
        protected IWebDriver driver;
        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}