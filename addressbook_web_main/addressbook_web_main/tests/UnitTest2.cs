using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_main
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
       

        [Test]
        public void GroupCreationTestm()
        {
          app.Navigat.OpenHomePage();
           app.Auth.Login(new AccountData ("admin","secret"));
            app.Navigat.GoToGroupsPage();
           app.GruopH.CreateNewGroup();
            GroupData group = new GroupData("test_mary");
            group.Header = "test_mary";
            group.Footer = "test_mary";
          app.GruopH.FillInGroupForm(group);
         app.GruopH.SubmitGroupCreation();
            app.GruopH.ReturnToGroupsPage();
        }

      
     

       

     

       

       
       


       

    

       
    }
}
