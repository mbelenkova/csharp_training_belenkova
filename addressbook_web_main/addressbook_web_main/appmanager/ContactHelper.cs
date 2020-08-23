using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{
    public class ContactHelper: HelperBase
    {

        public By IsContactPresent = By.ClassName("center");
        //private IWebDriver driver;
        public ContactHelper(ApplicationManager manager) :base(manager)
        {
          
         }
        public object ContactCreater(ContactData contact)
        {
            
            manager.Navigat.GoToContactPage();
            FillInDataFields(contact);
             SubmitNewContact();

            return this;
        }

        public ContactHelper ModifyContact(ContactData CoDatac)
        {
            manager.Navigat.OpenHomePage();
            SelectContact();
            InitContactModification();
            FillInDataFields(CoDatac);
            SubmitContactModification();
            return this;
        }

        public object ContactRemover()
        {   
           SelectContact();
           RemoveContact();
        
            return this;
        }
        public ContactHelper FillInDataFields(ContactData contact)
        {

            Type(By.Name("firstname"), contact.Firstname);

            Type(By.Name("middlename"), contact.Middlename);

            Type(By.Name("lastname"), contact.Lastname);

            Type(By.Name("nickname"), contact.Nickname);

            Type(By.Name("title"), contact.Title);

            Type(By.Name("company"), contact.Company);

            Type(By.Name("address"), contact.Address);

            Type(By.Name("home"), contact.Home);

            Type(By.Name("mobile"), contact.Mobile);

            Type(By.Name("work"), contact.Work);

            Type(By.Name("fax"), contact.Fax);

            Type(By.Name("email"), contact.Email);

            Type(By.Name("email2"), contact.Email2);

            Type(By.Name("email3"), contact.Email3);

            Type(By.Name("homepage"), contact.Homepage);

         
            TypeSelect(By.Name("bday"), contact.Bday);

            TypeSelect(By.Name("bmonth"), contact.Bmonth);

            Type(By.Name("byear"), contact.Byear);

            TypeSelect(By.Name("aday"), contact.Aday);

            TypeSelect(By.Name("amonth"), contact.Amonth);

            Type(By.Name("ayear"), contact.Ayear);

            Type(By.Name("address2"), contact.Address2);

            Type(By.Name("phone2"), contact.Phone2);

            Type(By.Name("notes"), contact.Notes);

            return this;
        }

       

        public ContactHelper SubmitNewContact()
        {
            //submit
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
          
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();

            return this;
        }
       
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[1]")).Click();
            return this;
        }
        
     /* private bool IsElementPresent(By by)
      {
           try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }*/
    }
}