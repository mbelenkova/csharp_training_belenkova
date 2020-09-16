using System;
using System.Drawing.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;



namespace addressbook_web_main
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTestsm()
        {

            app.Navigat.GoToGroupsPage();

           if (!app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent))
            {
               
                GroupData group = new GroupData("test_mary");
                group.Header = "test_mary";
                group.Footer = "test_mary";

               

                app.GruopH.Create(group);

              


            }

            List<GroupData> OldGroups = GroupData.GetAll();

            GroupData toBeRemoved = OldGroups[0];

            app.GruopH.Remove(toBeRemoved);
           

            List<GroupData> newGroups = GroupData.GetAll();

            //GroupData toBeRemoved = OldGroups[0];

            OldGroups.RemoveAt(0);

            Assert.AreEqual(OldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }


        }   

      
    }

   



}

    
       

       