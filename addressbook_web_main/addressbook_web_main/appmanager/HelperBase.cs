﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
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
        protected ApplicationManager manager;
        protected IWebDriver driver;
        protected bool present;
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {

                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
          
         }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void TypeSelect(By locatorc, string textc)
        {
            if (textc != null)
            {
                new SelectElement(driver.FindElement(locatorc)).SelectByText(textc);
            }


        }

    }
}