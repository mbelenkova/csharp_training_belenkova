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



namespace addressbook_web_main
{
    [TestFixture]
    public class GroupCreationTest : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();//создаем список

            for (int i =0; i<5;i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100), 
                    Footer = GenerateRandomString(100)


                }) ;
                
                    

                
            }
            return groups;
        }

       
        public static IEnumerable<GroupData> GroupDataFromCSVFile()
        {
            List<GroupData> groups = new List<GroupData>();//создаем список
            string [] lines=File.ReadAllLines(@"groups.csv");
            foreach(string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                     
                });
                   

            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXMLFile()
        {
            List<GroupData> groups = new List<GroupData>();//создаем список
            return (List<GroupData>)  new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader("groups.xml"));//читает данные listofGroupData из указанного файла
         
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {

          return  JsonConvert.DeserializeObject<List<GroupData>>
                (
                File.ReadAllText(@"groups.json")
                );
        }

        //TestCaseSourse - внешний источник тестовых данных
        [Test,TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTestm(GroupData group)
        {
          
           
         /*   GroupData group = new GroupData("test_mary");
            group.Header = "test_mary";
            group.Footer = "test_mary";
         */
            //передтем как добавлять группу мы получим список групп
            List<GroupData> OldGroups =GroupData.GetAll() ;

            app.GruopH.Create(group);

        
            //после того как группа добавлена мы получим список групп
            List <GroupData> newGroups = GroupData.GetAll();

            OldGroups.Add(group);

            OldGroups.Sort();
            newGroups.Sort();

            //ожидаемое значение OldGroups + 1 
            //фактическое  newGroups
//            Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(OldGroups, newGroups);
     
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
          //  Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);
           
            OldGroups.Add(group);

         

            OldGroups.Sort();
            newGroups.Sort();

            //ожидаемое значение OldGroups + 1 
            //фактическое  newGroups
            //            Assert.AreEqual(OldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(OldGroups, newGroups);

        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI= app.GruopH.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.WriteLine(end.Subtract(start));
            start = DateTime.Now;

            List<GroupData> fromDb = GroupData.GetAll();


            end = DateTime.Now;
            System.Console.WriteLine(end.Subtract(start));
        }
    }


     }

