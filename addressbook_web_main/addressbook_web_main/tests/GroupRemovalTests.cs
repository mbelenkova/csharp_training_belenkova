using System;
using System.Drawing.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



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


            app.GruopH.Remove();
                
                 

        }   

      
    }

   



}

    
       

       