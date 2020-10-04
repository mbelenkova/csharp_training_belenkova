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
    public  class AddProject: AuthTestBase
    {
        [Test]

        public void AddpRrojectTo()
        {
            app.Navigat.OpenManageFromMenu();
            app.Navigat.OpenManageProjectsFromMenu();


            // List<ProjectData> OldProjects = app.prManH.GetProjectsList();
            AccountData account = new AccountData("administrator", "root");
            List<ProjectData> Newlist = new List<ProjectData>();
            List<ProjectData> Oldlist = new List<ProjectData>();
            List<Mantis.ProjectData> OldProjects = app.prManH.GetProjectsListFromApi(account);

          

                for (int i = 0; i < OldProjects.Count; i++)
                {
                   
                    Oldlist.Add(new ProjectData(OldProjects[i].name, OldProjects[i].description));

                }

           
           

            Random rnd = new Random();
            int value = rnd.Next();

             ProjectData project = new ProjectData("name" + value, "desc");

            app.prManH.CreateNewProjectFromAPI(account, project);

            //  ProjectData projectData = new ProjectData("name" + value,"desc");

           
            //  app.prManH.Add(projectData);



          // List<ProjectData> NewProjects =  app.prManH.GetProjectsList();
            List<Mantis.ProjectData> NewProjects = app.prManH.GetProjectsListFromApi(account);

            for (int i = 0; i < NewProjects.Count; i++)
            {
               
                Newlist.Add(new ProjectData(NewProjects[i].name, NewProjects[i].description));

            }

          //  List<Mantis.ProjectData> between = NewProjects.Except(OldProjects).ToList();
            //Mantis.ProjectData project_to_add = between.First();

            List<ProjectData> pr_to_addList = Newlist.Except(Oldlist).ToList();
           ProjectData pr_to_add = pr_to_addList.First();



             //OldProjects.Add(project_to_add);
             Oldlist.Add(pr_to_add);
        

            Assert.AreEqual(Oldlist.Count,Newlist.Count);

            Oldlist.Sort();
            Newlist.Sort();

            Assert.AreEqual(Oldlist,Newlist);

        }



    }
}
