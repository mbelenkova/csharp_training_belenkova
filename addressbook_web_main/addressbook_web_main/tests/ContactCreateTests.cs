using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.IO;//ДЛЯ РАБОТЫ С ФАЙЛАМИ
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace addressbook_web_main
{
    [TestFixture]
    public class CreateNewContac : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5;i++)
            {
                contact.Add(new ContactData(GenerateRandomString(20), GenerateRandomString(20))

                {
                    Address = GenerateRandomString(100)


                }
                    ) ;
            }
            return contact;

        }

       public static IEnumerable<ContactData> ContactDataFromCSVFile()
        {
            List<ContactData> contact = new List<ContactData>();
          string [] lines =  File.ReadAllLines(@"contacts.csv"); //string[]lines- возвращаемое значение массив строк
            foreach (string l in lines)
            {
               string [] parts = l.Split(',');  //разбиваем получившиеся строкина куски

                contact.Add(new ContactData(parts[0], parts[1])
                {
                    Address = parts[2]
                    /*Home= parts[3],
                    Mobile=parts[4],
                    Work= parts[5],
                    Email = parts[6],
                    Email2 = parts[7],
                    Email3 = parts[8]*/
                });
              
            }
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            List<ContactData> contact = new List<ContactData>();
           
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader("contacts.xml"));
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>
              (
              File.ReadAllText(@"contacts.json")
              );
        }

        [Test, TestCaseSource("ContactDataFromJsonile")]
        public void CreateNewContacm(ContactData contact)
        {

      
            List<ContactData> oldContact = app.ContactH.GetContactList();

            app.ContactH.ContactCreater(contact);

         


            List<ContactData> newContact = app.ContactH.GetContactList();

            //Assert.AreEqual(oldContact.Count + 1, newContact.Count

             oldContact.Add(contact);

           

            newContact.Sort();
            oldContact.Sort();

          


            Assert.AreEqual(oldContact,newContact);

        }

       
       

       

       

      

     
    }
}
