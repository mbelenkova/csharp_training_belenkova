using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using addressbook_web_main;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generationm
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileType = args[0];
            int count = Convert.ToInt32(args[1]);//тут передаем количество данных которые хотим сгенерировать

            StreamWriter writer = new StreamWriter(args[2]);//куда мы хотим записывать (args[1])-потому что не указываем конкретное имяфайла, абудем указывать его все время разное при запуске
            string format = args[3];
           
            List<GroupData> groups = new List<GroupData>();//создаем список
            List<ContactData> contacts = new List<ContactData>();
            if (FileType == "group")
            {
                for (int i = 1; i < count; i++)
                {

                    groups.Add((new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)


                    }));


                    /*  contacts.Add((new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                      {
                         Address = TestBase.GenerateRandomString(50),

                      }));
      */

                }
                if (format == "scv")
                {
                    WriteGroupdToCsvFile(groups, writer);
                    //WriteContactsToCsvFile(contacts, writer);

                }
                else
                    if (format == "xml")
                {
                    WriteGroupsToXMLFile(groups, writer);
                    //  WriteContactsToXMLFile(contacts, writer);
                }
                else if(format == "json")
                {
                    WriteGroupsToJsonFile(groups,writer);
                }
                // WriteGroupdToCsvFile(groups,writer);
                // WriteContactsToCsvFile(contacts, writer);
                writer.Close();

            }

            if (FileType == "contact")
            {
                 for (int i = 1; i < count; i++)
                {


                   contacts.Add((new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                      {
                         Address = TestBase.GenerateRandomString(50),

                      }));
    

                }
                if (format == "scv")
                {
                    
                    WriteContactsToCsvFile(contacts, writer);

                }
                else
                    if (format == "xml")
                {
                    WriteContactsToXMLFile(contacts, writer);
                }
                else  if (format =="json")
                {
                    WriteContactsToJsonFile(contacts,writer);
                }
                // WriteGroupdToCsvFile(groups,writer);
                // WriteContactsToCsvFile(contacts, writer);
                writer.Close();
            }
        }
    
        static void WriteGroupdToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer
                   ));
            }
        }
        static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach(ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    contact.Firstname,
                    contact.Lastname,
                    contact.Address
                    ));
            }
        }
        static void WriteContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups,Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

    }
}