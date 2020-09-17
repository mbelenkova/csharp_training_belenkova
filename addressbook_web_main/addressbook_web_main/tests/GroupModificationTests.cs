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
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTestsm()
        {
            app.Navigat.GoToGroupsPage();

            if (!app.GruopH.IsElementPresent(app.GruopH.IsGroupPresent))
            {

                GroupData group = new GroupData("test_mary");
                group.Header = "test_mary";
                group.Footer = "test_mary";
                app.GruopH.Create(group);


            }

            GroupData newData = new GroupData("modifiedData");
            newData.Header = "modifiedData";
            newData.Footer = "modifiedData";

            List<GroupData> OldGroups = GroupData.GetAll();

            GroupData toBeChanged = OldGroups[0];

            // GroupData oldData = OldGroups[0];

            app.GruopH.AddChanges(toBeChanged,newData);

          //  app.GruopH.ModifyGroup(newData);

            List<GroupData> newGroups = GroupData.GetAll();

            OldGroups[0].Name = newData.Name;
            OldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(OldGroups,newGroups);

            foreach(GroupData group in newGroups)
            {
                if(group.Id == toBeChanged.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }


    }
}
