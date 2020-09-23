using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_main
{
    public class AddingContactToGroupTest : AuthTestBase
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




            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
           List <ContactData> oldContacts = ContactData.GetAll();
           ContactData contactToAdd = null;

          //List<ContactData> contact_to_add = ContactData.GetAll().Except(oldList).ToList();

            if (ContactData.GetAll().Except(oldList).ToList().Count == 0)
            {
                ContactData newCo = new ContactData("mary", "bel");

              newCo.Lastname = "bel";
            newCo.Nickname = "marybel";

            newCo.Address = "address";


            app.ContactH.ContactCreater(newCo);

            List<ContactData> newContacts = ContactData.GetAll();
            List<ContactData> ContactsWithoutGroup = newContacts.Except(oldList).ToList();
            contactToAdd = ContactsWithoutGroup[0];

                app.ContactH.AddContactToGroup(contactToAdd,group);

                List<ContactData> newList = group.GetContacts();

                oldList.Add(contactToAdd);

                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);


            }
            else
            {
                ContactData contact_to_add = ContactData.GetAll().Except(oldList).First();
                app.ContactH.AddContactToGroup(contact_to_add, group);

                List<ContactData> newList = group.GetContacts();

                oldList.Add(contact_to_add);

                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);

            }

        

            

        }
    }
}
