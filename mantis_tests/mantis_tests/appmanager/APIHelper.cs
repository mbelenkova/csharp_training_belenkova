using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewProjectNew(AccountData account,ProjectData project)
        {
           Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            // Mantis.IssueData issue = new Mantis.IssueData();
            //issue.summary = IssueData.Summary;
            //issue.description = IssueData.Description;
            // issue.category = IssueData.Category;
            //issue.project.name = project.Pr_name;
            // client.mc_issue_add(account.Name, account.Password, issue);
            Mantis.ProjectData project_new = new Mantis.ProjectData();
            project_new.name = project.Pr_name;
            project_new.description = project.Pr_description;
            client.mc_project_add(account.Name, account.Password, project_new);


          

        }
    }
}
