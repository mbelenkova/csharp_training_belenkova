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
    public class ContactHelper: HelperBase
    {

        public By IsContactPresent = By.ClassName("center");

      public string getContactInformationFromDetailsPage(int index)
        {
            manager.Navigat.OpenHomePage();

          
          driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();

            string list = driver.FindElement(By.Id("content")).Text;


            return list;

         

        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigat.OpenHomePage();
            ClearGroupFilter();
            SelectGroupInFilter(group.Name);
            SelectContact(contact.Id);
            RemoveContactFromGroupm();
        }

        private void SelectGroupInFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }
        private void RemoveContactFromGroupm()
        {
            driver.FindElement(By.Name("remove")).Click();
           // driver.SwitchTo().Alert().Accept();
           // driver.FindElement(By.CssSelector("div.msgbox"));

        }
        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigat.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
          driver.FindElement(By.Name("add")).Click();
            
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
            
        }

        public ContactData getContactInformationFromTable(int index)
        {
            manager.Navigat.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastname = cells[1].Text;


            string firstname = cells[2].Text;

            string address = cells[3].Text;

            string allPhones = cells[5].Text;

            string allEmails = cells[4].Text;

            return new ContactData(firstname, lastname)
            {

                Address = address,
                allPhones = allPhones,
                allEmails = allEmails
            };
    
        }

        


        public ContactData getContactInformationFromEditForm(int index)
        {
            manager.Navigat.OpenHomePage();
            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home  = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile= driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

           return new ContactData(firstname, lastname)
            {

                Address = address,
                Mobile =mobile,
                Home = home,
                Work = work,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

           
        }

      

        public ContactData ListofContactsEditPagee(int index)
        {
           manager.Navigat.OpenHomePage();
            InitContactModification(0);
          string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {

                Address = address,
                Mobile = mobile,
                Home = home,
                Work = work,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

            // string EqualOrNot = firstname + " " + lastname + "\r\n" + address + "\r\n" + "\r\n" + "H: " + home + "\r\n" + "M: " + mobile + "\r\n" + "W: " + work + "\r\n" + "\r\n" + email + "\r\n" + email2 + "\r\n" + email3;

            // return (firstname + " "+ lastname+ "\r\n"+ address+ "\r\n" + "\r\n" + "H: "+ home+ "\r\n" +"M: "+ mobile+ "\r\n"+"W: "+ work+ "\r\n" + "\r\n" + email+ "\r\n" + email2+ "\r\n" + email3).Trim(); 

        }

       


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
            InitContactModification(0);
            FillInDataFields(CoDatac);
            SubmitContactModification();
            return this;
        }

        public ContactHelper AddChanges(ContactData contact, ContactData CoDatac)
        {

            manager.Navigat.OpenHomePage();
            SelectContact(contact.Id);
            InitContactModification(0);
            FillInDataFields(CoDatac);
            SubmitContactModification();
            return this;
        }

        public object ContactRemover()
        {
            manager.Navigat.OpenHomePage();
            SelectContact();
           RemoveContact();
        
            return this;
        }

        internal object Remove(ContactData contact)
        {
            manager.Navigat.OpenHomePage();
            SelectContact(contact.Id);
            RemoveContact();

            return this;
        }

        public ContactHelper SelectContact(String id)
        {
             By loc = By.XPath("(//input[@name='selected[]' and @value='" + id + "'])");
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();

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

            ContactCach = null;
           
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
            ContactCach = null;

            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));

            return this;
        }
       
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            ContactCach = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();

           // driver.FindElement(By.XPath("(//img[@alt='Edit'])[1]")).Click();
            return this;
        }


        private List<ContactData> ContactCach = null;

        internal List<ContactData> GetContactList()
        {

            if (ContactCach ==null)
            {
                ContactCach = new List<ContactData>();
                //чтобы посчитать группы нужно сначала перейти на нужнуюб страницу
                manager.Navigat.OpenHomePage();
                //далее нужно прочитать список элементов(групп, которые присутствуют на странице)
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry")); //нас интересуют элементы которые будут иметь тег спан и класс групп

                //когда список элементов получен его нудно куда-нибудь сохранить - elements
                //теперь эти элементы этообьекты типа ICollection превратить в нужный нам элемент типа gROUPData
                foreach (IWebElement element in elements)//для каждого элемента нудно выполнить действия в такой-то коллекции
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                  //  ContactData contact = 
                    

                    //contacts.Add(new ContactData(element.Text));

                    ContactCach.Add(new ContactData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")

                    });


                }

            }
            //готовим пустой список элементов типа GroupData
            /* List<ContactData> contacts = new List<ContactData>();
            // List<ContactData> contactsLastName = new List<ContactData>();

             //чтобы посчитать группы нужно сначала перейти на нужнуюб страницу
             manager.Navigat.OpenHomePage();
             //далее нужно прочитать список элементов(групп, которые присутствуют на странице)
             ICollection<IWebElement> elements = driver.FindElements(By.Name("entry")); //нас интересуют элементы которые будут иметь тег спан и класс групп

             //когда список элементов получен его нудно куда-нибудь сохранить - elements
             //теперь эти элементы этообьекты типа ICollection превратить в нужный нам элемент типа gROUPData
             foreach (IWebElement element in elements)//для каждого элемента нудно выполнить действия в такой-то коллекции
             {
                 IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                 //contacts.Add(new ContactData(element.Text));

                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));


             }
            */
            return new List<ContactData>(ContactCach);
           
            
        }

       public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigat.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
           Match m = new Regex(@"\d +").Match(text);//создаем регулярное выражение и применяем его к тексту
          return  Int32.Parse(m.Value);
        }

    }
}