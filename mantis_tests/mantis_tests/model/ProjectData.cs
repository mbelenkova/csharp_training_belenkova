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
   public class ProjectData
    {
        private string pr_name = "";
        private string pr_description = "";

        public ProjectData(string pr_name, string pr_description)
        {
           this.pr_name = pr_name;
           this.pr_description = pr_description;


        }



        public string Pr_name
        {
            get
            {
                return pr_name;
            }
            set
            {
               pr_name = value;
            }
        }

        public string Pr_description
        {
            get
            {
                return pr_description;
            }
            set
            {
               pr_description = value;
            }
        }
    }

}
