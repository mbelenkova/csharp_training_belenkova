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

             
            if (!app.ContactH.IsElementPresent(app.ContactH.IsContactPresent))
            {
                ContactData contact_present = new ContactData("mary", "bel");

                contact_present.Lastname = "bel";
                contact_present.Nickname = "marybel";

                contact_present.Address = "address";


                app.ContactH.ContactCreater(contact_present);


            }
            else
            if (!app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent))
            {

                GroupData group_present = new GroupData("test_mary");
                group_present.Header = "test_mary";
                group_present.Footer = "test_mary";



               app.GruopH.Create(group_present);



            }
            else
            if (!app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent) && !app.ContactH.IsElementPresent(app.ContactH.IsContactPresent))
            {
                ContactData contact_present = new ContactData("mary", "bel");

                contact_present.Lastname = "bel";


                contact_present.Address = "address";




                app.ContactH.ContactCreater(contact_present);


                GroupData group_present = new GroupData("test_mary");
                group_present.Header = "test_mary";
                group_present.Footer = "test_mary";



                app.GruopH.Create(group_present);


            }
           
            if (app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent) && app.ContactH.IsElementPresent(app.ContactH.IsContactPresent))
            {

                foreach (ContactData contact in ContactData.GetAll())//беру контакты из списка контактов
                {


                    GroupData group = GroupData.GetAll()[0];

                    List<GroupData> groupn = contact.GetGroups();

                    List<ContactData> oldList = group.GetContacts();



                    if (groupn.Count == 0)
                    {
                        app.ContactH.AddContactToGroup(contact, group);

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


                }




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
