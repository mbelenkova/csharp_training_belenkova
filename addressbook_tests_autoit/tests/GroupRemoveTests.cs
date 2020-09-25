using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
  public  class GroupRemoveTests:TestBase
    {


        [Test]
        public void TestGroupRemoval()
        {
            int group_to_remove_index;
            //Assert.Pass();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count <= 1)
            {  
                GroupData newGroup = new GroupData()
                {
                    Name = "test"
                };

                app.Groups.Add(newGroup);

                oldGroups = app.Groups.GetGroupList();
            }

            group_to_remove_index = oldGroups.Count - 1; // the last one

            GroupData groupdel = oldGroups[group_to_remove_index];//vixtumgr

            oldGroups.RemoveAt(group_to_remove_index);

            
            app.Groups.OpenGroupsDialog();
            app.Groups.RemoveGroup(group_to_remove_index);
            app.Groups.CloseGroupsDialog();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);
        }

  
    }
    }
