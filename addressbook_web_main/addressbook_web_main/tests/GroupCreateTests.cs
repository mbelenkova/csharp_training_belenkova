using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_main
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {


        [Test]
        public void GroupCreationTestm()
        {
          
           
            GroupData group = new GroupData("test_mary");
            group.Header = "test_mary";
            group.Footer = "test_mary";
            app.GruopH.Create(group);

     
        }
        [Test]
        public void EmpytGroupCreationTestm()
        {

           
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.GruopH.Create(group);


        }
    }


     }

