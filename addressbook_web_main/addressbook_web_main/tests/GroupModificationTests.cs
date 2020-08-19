using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_main
{

    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTestsm()
        {
            app.Navigat.GoToGroupsPage();

            if (!IsElementPresent(By.ClassName("group")))
            {

                GroupData group = new GroupData("test_mary");
                group.Header = "test_mary";
                group.Footer = "test_mary";
                app.GruopH.Create(group);


            }

            GroupData newData = new GroupData("modifiedData");
            newData.Header = "modifiedData";
            newData.Footer = "modifiedData";

            app.GruopH.ModifyGroup(newData);

        }


        private bool IsElementPresent(By by)
        {
            try
            {
                app.Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
