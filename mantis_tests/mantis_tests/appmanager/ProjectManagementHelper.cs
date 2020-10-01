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
        private List<ProjectData> ContactCach = null;

        internal List<ProjectData> GetProjectsList()
        {
            if (ContactCach == null)
            {
                ContactCach = new List<ProjectData>();
                manager.Navigat.OpenManageFromMenu();
                manager.Navigat.OpenManageProjectsFromMenu();

                //  ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("div.table-responsive"));

                IWebElement NTable = driver.FindElement(By.CssSelector("tbody"));//беру таблицу

                ICollection<IWebElement> elements = NTable.FindElements(By.TagName("tr"));//получаювсе записи, которые у нас есть


                foreach (IWebElement element in elements)
                {

                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                    ContactCach.Add(new ProjectData(cells[0].Text, cells[4].Text));

                }


            }

            return new List<ProjectData> (ContactCach);
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
