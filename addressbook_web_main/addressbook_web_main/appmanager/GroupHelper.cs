﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{
   public class GroupHelper: HelperBase
    {
       // private IWebDriver driver;
        public GroupHelper(IWebDriver driver ) : base(driver)
        {
            
            
        }
       public void CreateNewGroup()
        {

            driver.FindElement(By.Name("new")).Click();
        }
        public void FillInGroupForm(GroupData group)
        {

            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        public void ReturnToGroupsPage()
        {

            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
