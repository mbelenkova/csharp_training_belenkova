﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{

    [TestFixture]
    public  class ContactModificationTests:ContactTestBase
    {
        [Test]
        public void ContactModificationTestsm()
        {

            if (!app.ContactH.IsElementPresent(app.ContactH.IsContactPresent))
            {

                ContactData contact = new ContactData("mary", "bel");
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
                app.ContactH.ContactCreater(contact);

            }
            app.Navigat.OpenHomePage();
            ContactData CoDatac = new ContactData("Modifyed111", "Modifyedbel");
           // CoDatac.Middlename = "Modifyedbel";
            CoDatac.Lastname = "Modifyedbel";
            CoDatac.Nickname = "Modifyedmarybel";
            CoDatac.Title = "Modifyedtitle";
            CoDatac.Company = "Modifyedcompany";
            CoDatac.Address = "Modifyedaddress";
            CoDatac.Home = "111111";
            CoDatac.Mobile = "2222222";
            CoDatac.Work = "333333";
            CoDatac.Fax = "4444444";
            CoDatac.Email = "testModifyed@test.test";
            CoDatac.Email2 = "test2Modifyed@mail.local";
            CoDatac.Email3 = "test3Modifyed@mail.local";
            CoDatac.Homepage = "hpomepageModifyed";
            CoDatac.Bday = "17";
            CoDatac.Bmonth = "February";
            CoDatac.Byear = "1991";
            CoDatac.Aday = "17";
            CoDatac.Amonth = "March";
            CoDatac.Ayear = "2000";
            CoDatac.Address2 = "address2v";
            CoDatac.Phone2 = "55555555";
            CoDatac.Notes = "testModifyed";

            List<ContactData> oldContact = ContactData.GetAll();

            ContactData toBeChanged = oldContact[0];

            app.ContactH.AddChanges(toBeChanged,CoDatac);
           // app.ContactH.ModifyContact(CoDatac);

           

            List<ContactData> newContact = ContactData.GetAll();

          //  ContactData oldData = oldContact[0];

            oldContact[0].Firstname = CoDatac.Firstname;
            oldContact[0].Lastname = CoDatac.Lastname;

            oldContact.Sort();

            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);


            foreach (ContactData contact in newContact)
            {
                if (contact.Id == toBeChanged.Id)
                {
                    Assert.AreEqual(CoDatac.Firstname,contact.Firstname);
                    Assert.AreEqual(CoDatac.Lastname,contact.Lastname);
                }
            }
        }

    }
}
