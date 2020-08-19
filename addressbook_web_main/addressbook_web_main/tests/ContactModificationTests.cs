using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_main
{

    [TestFixture]
    public  class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTestsm()
        {
            ContactData CoDatac = new ContactData("Modifyed111");
            CoDatac.Middlename = "Modifyedbel";
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

            

            app.ContactH.ModifyContact(CoDatac);
        }
    }
}
