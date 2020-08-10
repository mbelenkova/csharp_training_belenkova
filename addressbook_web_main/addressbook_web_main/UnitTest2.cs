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
            OpenHomePage();
            Login(new AccountData ("admin","secret"));
            GoToGroupsPage();
            CreateNewGroup();
            GroupData group = new GroupData("test_mary");
            group.Header = "test_mary";
            group.Footer = "test_mary";
            FillInGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }

      
     

       

     

       

       
       


       

    

       
    }
}
