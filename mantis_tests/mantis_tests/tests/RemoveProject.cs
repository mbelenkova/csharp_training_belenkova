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
            //проверка на то, что есть группы для удаления
            //если нет групп,создать
            //записываем в олдлист
           if(!app.prManH.IsElementPresent(app.prManH.IsProjectPresent))

            {
                Random rnd = new Random();
                int value = rnd.Next();


                ProjectData projectData = new ProjectData("first" + value, "descFirst");


                app.prManH.Add(projectData);
            }

            List<ProjectData> OldProjects = app.prManH.GetProjectsList();

            app.prManH.RemoveProject();

            List<ProjectData> NewProjects = app.prManH.GetProjectsList();

            List<ProjectData> need_remove = OldProjects.Except(NewProjects).ToList();


            ProjectData toBeRemoved = need_remove.First();

            OldProjects.Remove(toBeRemoved);

            OldProjects.Sort();
            NewProjects.Sort();

            Assert.AreEqual(OldProjects, NewProjects);

            Assert.AreEqual(OldProjects.Count, NewProjects.Count);


           

          

          


        }
    }
}
