using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace mantis_tests
{
    [TestFixture]
   public class RemoveProject:AuthTestBase
    {
        [Test]

        public void removeProject()
        {
            app.Navigat.OpenManageFromMenu();
            app.Navigat.OpenManageProjectsFromMenu();
            List<ProjectData> Newlist = new List<ProjectData>();
            List<ProjectData> Oldlist = new List<ProjectData>();
            AccountData account = new AccountData("administrator", "root");

            if (!app.prManH.IsElementPresent(app.prManH.IsProjectPresent))

            {

                Random rnd = new Random();
                int value = rnd.Next();


                ProjectData project = new ProjectData("new" + value, "new");

                app.prManH.CreateNewProjectFromAPI(account, project);
               
            }

            List<Mantis.ProjectData> OldProjects = app.prManH.GetProjectsListFromApi(account);


            for (int i = 0; i < OldProjects.Count; i++)
            {

                Oldlist.Add(new ProjectData(OldProjects[i].name, OldProjects[i].description));

            }
            app.Navigat.OpenManageFromMenu();
            app.Navigat.OpenManageProjectsFromMenu();

            app.prManH.RemoveProject();




            List<Mantis.ProjectData> NewProjects = app.prManH.GetProjectsListFromApi(account);


            for (int i = 0; i < NewProjects.Count; i++)
            {

                Newlist.Add(new ProjectData(NewProjects[i].name, NewProjects[i].description));

            }

            List<ProjectData> pr_to_removeList = Oldlist.Except(Newlist).ToList();
            ProjectData toBeRemoved = pr_to_removeList.First();

            Oldlist.Remove(toBeRemoved);


            Assert.AreEqual(Oldlist.Count, Newlist.Count);

            Oldlist.Sort();
            Newlist.Sort();


            Assert.AreEqual(Oldlist,Newlist);

          

          


        }
    }
}
