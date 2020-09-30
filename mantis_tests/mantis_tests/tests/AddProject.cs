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

            Random rnd = new Random();
            int value = rnd.Next();


            ProjectData projectData = new ProjectData("first"+value,"descFirst");


            app.prManH.Add(projectData);

        }



    }
}
