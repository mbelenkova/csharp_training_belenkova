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

            List<ContactData> newList = group.GetContacts();

            //List<ContactData> contact_to_add = ContactData.GetAll().Except(oldList).ToList();

            if (ContactData.GetAll().Except(oldList).ToList().Count == 0)
            {
                ContactData newCo = new ContactData("mary1", "bel1");

              newCo.Lastname = "bel1";
            newCo.Nickname = "marybel1";

            newCo.Address = "address1";


            app.ContactH.ContactCreater(newCo);

            List<ContactData> newContacts = ContactData.GetAll();
            List<ContactData> ContactsWithoutGroup = newContacts.Except(oldList).ToList();
            contactToAdd = ContactsWithoutGroup[0];

                app.ContactH.AddContactToGroup(contactToAdd,group);

                newList = group.GetContacts();

                oldList.Add(contactToAdd);

                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);


            }
            else
            {
                ContactData contact_to_add = ContactData.GetAll().Except(oldList).First();

                app.ContactH.AddContactToGroup(contact_to_add, group);

                newList = group.GetContacts();

                oldList.Add(contact_to_add);

                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);

            }

        

            

        }
    }
}
