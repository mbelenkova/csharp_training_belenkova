using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_main
{

  public  class DeleteContactFromGroup:AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroup()
        {

             GroupData group = GroupData.GetAll()[0];
            

            foreach (ContactData contact in ContactData.GetAll())//беру контакты из списка контактов
            {

          

                List<GroupData> groupn = contact.GetGroups();

                List<ContactData> oldList = group.GetContacts();



                if (groupn.Count == 0)
                {
                    app.ContactH.AddContactToGroup(contact,group);
                    
                    app.ContactH.RemoveContactFromGroup(contact, group);

                }
                else
                {
                    app.ContactH.RemoveContactFromGroup(contact, group);
                }

                oldList.RemoveAt(0);

                List<ContactData> newList = group.GetContacts();

                Assert.AreEqual(oldList, newList);

                foreach (ContactData contacts in ContactData.GetAll())
                {
                    Assert.AreNotEqual(group.Id, contact.Id);
                }

                /*  List<ContactData> newList = group.GetContacts();

                  oldList.RemoveAt(0);

                  newList.Sort();
                  oldList.Sort();

                  Assert.AreEqual(oldList, newList);
                */
            }

            

          



            /*
             {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact =  ContactData.GetAll().Except(oldList).First();

            //actions

            app.ContactH.AddContactToGroup(contact,group);
            */

            //actions



            //  app.ContactH.RemoveContactFromGroup(contact,group);





        }


    }
}
