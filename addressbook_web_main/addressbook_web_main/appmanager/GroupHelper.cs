using System;
using System.CodeDom;
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
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

            
        }

        public GroupHelper Remove()
        {

           manager.Navigat.GoToGroupsPage();
            SelectGroup();
            RemoveGroups();
            return this;
        }

        public GroupHelper ModifyGroup(GroupData newData)
        {
            manager.Navigat.GoToGroupsPage();
            SelectGroup();
            InitGroupModification();
            FillInGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

       

        public GroupHelper Create(GroupData group)
        {
            
            manager.Navigat.GoToGroupsPage();
            CreateNewGroup();
            FillInGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }
      

        public GroupHelper CreateNewGroup()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        
        public GroupHelper FillInGroupForm(GroupData group)
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
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {

            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[1]")).Click();
            return this;
        }
        public GroupHelper RemoveGroups()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;

        }
    }
}
