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
            app.Navigat.OpenHomePage();
             
            if (!app.ContactH.IsElementPresent(app.ContactH.IsContactPresent))
            {
                ContactData contact = new ContactData("mary", "bel");

                contact.Lastname = "bel";
                contact.Nickname = "marybel";

                contact.Address = "address";


                app.ContactH.ContactCreater(contact);


            }
            app.Navigat.GoToGroupsPage();
            if (!app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent))
            {

                GroupData group = new GroupData("test_mary");
                group.Header = "test_mary";
                group.Footer = "test_mary";



                app.GruopH.Create(group);

            



            }
           
              app.Navigat.OpenHomePage();
            if (!app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent) && !app.ContactH.IsElementPresent(app.ContactH.IsContactPresent))
            {
                ContactData contact= new ContactData("mary", "bel");

                contact.Lastname = "bel";


                contact.Address = "address";




                app.ContactH.ContactCreater(contact);


                GroupData group = new GroupData("test_mary");
                group.Header = "test_mary";
                group.Footer = "test_mary";



                app.GruopH.Create(group);

                


            }
           
           

                foreach (ContactData contact in ContactData.GetAll())//беру контакты из списка контактов
                {



                GroupData group = GroupData.GetAll()[0];


                List<GroupData> groupn = contact.GetGroups();


                List<ContactData> oldList = group.GetContacts();


                if (groupn.Count == 0)
                    {
                        app.ContactH.AddContactToGroup(contact, group);

                       oldList = group.GetContacts();

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
