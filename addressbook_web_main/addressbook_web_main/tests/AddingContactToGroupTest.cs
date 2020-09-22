using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_main
{
   public class AddingContactToGroupTest: AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()
        {

            app.Navigat.OpenHomePage();

            if (!app.ContactH.IsElementPresent(app.ContactH.IsContactPresent))
            {
                ContactData contact_t = new ContactData("mary", "bel");

                contact_t.Lastname = "bel";
                contact_t.Nickname = "marybel";

                contact_t.Address = "address";


                app.ContactH.ContactCreater(contact_t);


            }
            app.Navigat.GoToGroupsPage();
            if (!app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent))
            {

                GroupData group_t = new GroupData("test_mary");
                group_t.Header = "test_mary";
                group_t.Footer = "test_mary";



                app.GruopH.Create(group_t);



            }

            app.Navigat.OpenHomePage();
            if (!app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent) && !app.ContactH.IsElementPresent(app.ContactH.IsContactPresent))
            {
                ContactData contact_t = new ContactData("mary", "bel");

                contact_t.Lastname = "bel";


                contact_t.Address = "address";




                app.ContactH.ContactCreater(contact_t);


                GroupData group_t = new GroupData("test_mary");
                group_t.Header = "test_mary";
                group_t.Footer = "test_mary";



                app.GruopH.Create(group_t);




            }

            GroupData group = GroupData.GetAll()[0];

            List<ContactData> oldList = group.GetContacts();

            foreach (ContactData contact in ContactData.GetAll())
            {


              


              //  List<ContactData> oldList = group.GetContacts();

          //    ContactData  contact = ContactData.GetAll().Except(oldList).First();


                //actions
                if (contact.GetGroups().Count == GroupData.GetAll().Count)
                {

                    // app.Navigat.OpenHomePage();
                   ContactData newCo = new ContactData("mary", "bel");

                    newCo.Lastname = "bel";
                    newCo.Nickname = "marybel";

                    newCo.Address = "address";


                    app.ContactH.ContactCreater(newCo);

                    app.ContactH.AddContactToGroup(contact, group);

                 //   oldList = group.GetContacts();

                   


                }
                else

                {
                   
                    app.ContactH.AddContactToGroup(contact, group);
                }


                List<ContactData> newList = group.GetContacts();

                oldList.Add(contact);

                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);


            }

        }
    }
}
