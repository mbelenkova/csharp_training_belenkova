using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_main
{
    [TestFixture]
    public class CreateNewContac : TestBase
    {
       

        [Test]
        public void CreateNewContacm()
        {

            ContactData contact = new ContactData("mary");
            contact.Middlename = "bel";
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
            app.ContactH.ContactCreater(contact);
                       
        }

       
       

       

       

      

     
    }
}
