using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace mantis_tests
{
 public class ProjectManagementHelper:HelperBase
    {
        public By IsProjectPresent = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a");
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ProjectManagementHelper Add(ProjectData projectData)
        {
            InitProjectCreation();
            FillFields(projectData);
            SumbitNewProject();
            return this;

        }

        public ProjectManagementHelper RemoveProject()
        {

            SelectProject();
            InitRemoving();
            ConfirmRemoving();
            return this;
        }

        public ProjectManagementHelper ConfirmRemoving()
        {
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/form/input[4]")).Click();
            return this;
        }

        public ProjectManagementHelper InitRemoving()
        {
            driver.FindElement(By.XPath("//form[@id='project-delete-form']/fieldset/input[3]")).Click();
            return this;
        }

        public ProjectManagementHelper SelectProject()
        {
           
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a")).Click();
            return this;

        }

        public ProjectManagementHelper SumbitNewProject()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            return this;
        }

       public ProjectManagementHelper FillFields(ProjectData projectData)
        {
            Type(By.Name("name"), projectData.Pr_name);
            Type(By.Name("description"), projectData.Pr_description);
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }


    }
}
