﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
  public  class ManagementMenuHelper : HelperBase
    {
        
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
           
        }

        public void OpenManageFromMenu()
        {
            //driver.FindElement(By.CssSelector("i.menu-icon.fa.fa-gears")).Click();
            // driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[6]/a/i")).Click();
            driver.FindElement(By.CssSelector("i.menu-icon.fa.fa-gears")).Click();
        }

        public void OpenManageProjectsFromMenu()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }
    }
}
