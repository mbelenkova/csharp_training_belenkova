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
   public class ProjectData: IEquatable<ProjectData>, IComparable<ProjectData>
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

       
        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other.pr_name, null) && (Object.ReferenceEquals(other.pr_description, null)))//если тот обьект с которым мы сравниваем равен нул то возвращаем фолсе
            {
                return false;

            }
            if (Object.ReferenceEquals(this, other.pr_name) && (Object.ReferenceEquals(this, other.pr_description) ))
            {
               
                return true;
            }

            return Pr_name== other.Pr_name&& Pr_description == other.Pr_description;
            //return Lastname == other.Lastname;


        }

        public override int GetHashCode()
        {



            return Pr_name.GetHashCode();
            // return Firstname.GetHashCode(); 


        }


        public override string ToString()
        {
            // return Firstname;
            return ("name=" + Pr_name + "\ndescription=" + Pr_description);



        }

        public int CompareTo(ProjectData other)
        {

            if (object.ReferenceEquals(other, null))

            {
                return 1;

            }


            if ((Pr_name.CompareTo(other.Pr_name)) == 0)

            {
                return Pr_description.CompareTo(other.Pr_description);

            }


            return (Pr_name.CompareTo(other.Pr_name));



        }
    }

}
