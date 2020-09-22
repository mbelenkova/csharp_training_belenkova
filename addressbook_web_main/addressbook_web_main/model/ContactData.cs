using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace addressbook_web_main
{ 
    [Table(Name = "addressbook")]
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

        public ContactData()
        {
           


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


        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]

        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; 
        }
        [Column(Name = "home")]
        public string Home { get; set; }
        [Column(Name = "mobile")]
        public string Mobile { get; set; }
        [Column(Name = "work")]
        public string Work { get; set; }
        
        [Column (Name = "deprecated")]
        public string Deprecated { get; set; }

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
        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "bday")]
        public string Bday { get; set; }
        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }
        [Column(Name = "byear")]
        public string Byear { get; set; }
        [Column(Name = "aday")]
        public string Aday { get; set; }
        [Column(Name = "amonth")]
        public string Amonth { get; set; }
        [Column(Name = "ayear")]
        public string Ayear { get; set; }
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "phone2")]
        public string Phone2 { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }
        [Column(Name = "photo")]
        public string Photo { get; set; }
        [Column(Name = "id"),PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())//устанавливает соединение)
            {
               return (from c in db.Contacts select c).ToList();
            }
        }

        public List<GroupData> GetGroups()
        {
            using (AddressbookDB db = new AddressbookDB())
            {

                return (from g in db.Groups from gcr in db.GCR.Where(P => P.GroupId == g.Id && P.ContactId == Id && g.Deprecated == "0000-00-00 00:00:00") select g).Distinct().ToList();


            }
        }
    }
}
