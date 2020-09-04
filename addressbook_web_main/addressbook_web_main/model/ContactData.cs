using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace addressbook_web_main
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
       //private string allphones;
      // private string allemails;
       // public string firstname;
      //  public string middlename = "";
        private string lastname = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";
        private string photo = "";
        private string allphones;
        private string allemails;
        private string allList;
        private string allEditList;

        //private string allList;

        public ContactData(string firstname,string lastname)
        {
           Lastname= lastname;
           Firstname =firstname;
            

        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other.Lastname, null)&& (Object.ReferenceEquals(other.Firstname, null)))//если тот обьект с которым мы сравниваем равен нул то возвращаем фолсе
            {
                return false;

            }
            if (Object.ReferenceEquals(this, other.Lastname)&& (Object.ReferenceEquals(this, other.Firstname)))
            {
                return true;
            }

            return Lastname == other.Lastname && Firstname == other.Firstname;
           //return Lastname == other.Lastname;
            

        }
        public override int GetHashCode()
        {



          return Lastname.GetHashCode();
          // return Firstname.GetHashCode(); 


        }

  
        public override string ToString()
        {
          // return Firstname;
           return ("lastname="+Lastname +"\nfirstname="+Firstname+"\naddress="+address);

           

        }

        public int CompareTo(ContactData other)
        {

          if (object.ReferenceEquals(other, null))

          {
                return 1;

           }

        
         if ((Lastname.CompareTo(other.Lastname)) == 0)

          {
              return Firstname.CompareTo(other.Firstname);

          }


            return (Lastname.CompareTo(other.Lastname));



        }



        public string Firstname { get; set; }
       
        public string Middlename { get; set; }
      
        public string Lastname { get; set; }
       /* {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
       */
       
        public string Nickname { get; set; }
      
        public string Title { get; set; }
      
        public string Company { get; set; }
        
        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }
        public string Work { get; set; }

        public string allPhones

        {
            get
            {
                if (allphones!=null)
                {
                    return allphones;
                }
                else 
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
                }

            }

            set
            {
                allphones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else 
            {
                //первый параметр это в чем мы будем заменять
                //второй параметр чтомы будем заменять
                //третийпараметр на что будем заменять

                return Regex.Replace(phone,"([-()])", "");  //phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            }
          
        }

        public string allEmails
        {
            get
            {
                if (allemails != null)
                {
                    return allemails;
                }
                else
                {
                    return (CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
                }

            }


            set
            {
                allemails = value;
            }
        }

     

        private string CleanUpEmails(string emailm)
        {
            if (emailm == null || emailm =="")
            {
                return "";
            }
            else
            {
              return  emailm.Replace(" ", "") + "\r\n";
            }
           
        }

       
      /* public string allDataEditPage
        
        {
            get 
             {
                if (allEditList != null)
                {
                    return allEditList;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)+ CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
                }


            }
            set
            {
                allEditList = value;
            }
        
        }
      */
        public string Fax { get; set; }
       
        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }
      
        public string Homepage { get; set; }

    public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string Photo { get; set; }

        public string Id { get; set; }
    }
}
