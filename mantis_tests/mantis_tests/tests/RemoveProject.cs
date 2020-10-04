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
            AccountData account = new AccountData("administrator", "root");

            if (!app.prManH.IsElementPresent(app.prManH.IsProjectPresent))

            {

                Random rnd = new Random();
                int value = rnd.Next();


                ProjectData project = new ProjectData("new" + value, "new");

                app.prManH.CreateNewProjectFromAPI(account, project);
               
            }

            List<Mantis.ProjectData> OldProjects = app.prManH.GetProjectsListFromApi(account);

            app.prManH.RemoveProject();

            List<Mantis.ProjectData> NewProjects = app.prManH.GetProjectsListFromApi(account);

            List<Mantis.ProjectData> need_remove = OldProjects.Except(NewProjects).ToList();


            Mantis.ProjectData toBeRemoved = need_remove.First();

            OldProjects.Remove(toBeRemoved);


            Assert.AreEqual(OldProjects.Count, NewProjects.Count);


           

          

          


        }
    }
}
