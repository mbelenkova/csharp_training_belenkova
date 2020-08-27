﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

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
            //передтем как добавлять группу мы получим список групп
            List<GroupData> OldGroups = app.GruopH.GetGroupList();
            app.GruopH.Create(group);
           //после того как группа добавлена мы получим список групп
           List <GroupData> newGroups = app.GruopH.GetGroupList();

            OldGroups.Add(group);

            OldGroups.Sort();
            newGroups.Sort();

            //ожидаемое значение OldGroups + 1 
            //фактическое  newGroups
//            Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(OldGroups, newGroups);
     
        }
        [Test]
        public void EmpytGroupCreationTestm()
        {

           
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            //передтем как добавлять группу мы получим список групп
            List<GroupData> OldGroups = app.GruopH.GetGroupList();

            app.GruopH.Create(group);
            //после того как группа добавлена мы получим список групп
            List<GroupData> newGroups = app.GruopH.GetGroupList();

            Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);

            OldGroups.Add(group);

            OldGroups.Sort();
            newGroups.Sort();

            //ожидаемое значение OldGroups + 1 
            //фактическое  newGroups
            //            Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(OldGroups, newGroups);

            //ожидаемое значение OldGroups + 1 
            //фактическое  newGroups
            //  Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);


        }


        [Test]
        public void BadNameGroupCreationTestm()
        {


            GroupData group = new GroupData("a'a");
            group.Header = " ";
            group.Footer = " ";
            //передтем как добавлять группу мы получим список групп
            List<GroupData> OldGroups = app.GruopH.GetGroupList();
            app.GruopH.Create(group);
            //после того как группа добавлена мы получим список групп
            List<GroupData> newGroups = app.GruopH.GetGroupList();

            //ожидаемое значение OldGroups + 1 
            //фактическое  newGroups
            Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);
            OldGroups.Add(group);

            OldGroups.Sort();
            newGroups.Sort();

            //ожидаемое значение OldGroups + 1 
            //фактическое  newGroups
            //            Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(OldGroups, newGroups);

        }
    }


     }
