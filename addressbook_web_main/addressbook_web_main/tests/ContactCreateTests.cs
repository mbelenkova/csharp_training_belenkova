using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.IO;//ДЛЯ РАБОТЫ С ФАЙЛАМИ


namespace addressbook_web_main
{
    [TestFixture]
    public class CreateNewContac : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5;i++)
            {
                contact.Add(new ContactData(GenerateRandomString(20), GenerateRandomString(20))

                {
                    Address = GenerateRandomString(100)


                }
                    ) ;
            }
            return contact;

        }

       public static IEnumerable<ContactData> ContactDataFromFile()
        {
            List<ContactData> contact = new List<ContactData>();
          string [] lines =  File.ReadAllLines(@"contacts.csv"); //string[]lines- возвращаемое значение массив строк
            foreach (string l in lines)
            {
               string [] parts = l.Split(',');  //разбиваем получившиеся строкина куски

                contact.Add(new ContactData(parts[0], parts[1])
                {
                    Address = parts[2],
                    Home= parts[3],
                    Mobile=parts[4],
                    Work= parts[5],
                    Email = parts[6],
                    Email2 = parts[7],
                    Email3 = parts[8]
                });
              
            }
            return contact;
        }

        [Test, TestCaseSource("ContactDataFromFile")]
        public void CreateNewContacm(ContactData contact)
        {

          /*  ContactData contact = new ContactData("mary","bel");
            //contact.Middlename = "bel";
            contact.Lastname = "bel";
            contact.Nickname = "marybel";
            contact.Title = "title";
            contact.Company = "company";
            contact.Address = "address";
            contact.Home = "111111";
            contact.Mobile = "2222222";
            contact.Work = "333333";
            contact.Fax = "4444444";
            contact.Email = "test@test.test";
            contact.Email2 = "test2@mail.local";
            contact.Email3 = "test3@mail.local";
            contact.Homepage = "hpomepage";
            contact.Bday = "17";
            contact.Bmonth = "February";
            contact.Byear = "1991";
            contact.Aday = "17";
            contact.Amonth = "March";
            contact.Ayear = "2000";
            contact.Address2 = "address2";
            contact.Phone2 = "55555555";
            contact.Notes = "test";
            // contact.Photo = "D:\test.png";
          */
            List<ContactData> oldContact = app.ContactH.GetContactList();

            app.ContactH.ContactCreater(contact);

         


            List<ContactData> newContact = app.ContactH.GetContactList();

            //Assert.AreEqual(oldContact.Count + 1, newContact.Count

             oldContact.Add(contact);

           

            newContact.Sort();
            oldContact.Sort();

          


            Assert.AreEqual(oldContact,newContact);

        }

       
       

       

       

      

     
    }
}
