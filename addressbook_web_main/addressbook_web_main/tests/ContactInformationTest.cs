using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_main
{
    [TestFixture]
  public  class ContactInformationTest: AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.ContactH.getContactInformationFromTable(0);

            ContactData fromForm = app.ContactH.getContactInformationFromEditForm(0);


            string fromDetails = app.ContactH.getContactInformationFromDetailsPage(0);

          ContactData fromEditPage =app.ContactH.ListofContactsEditPagee(0);

            string FLName;
            string WAddress;
            string WHome;
            string WMobile;
            string WWork;
            string WEmail;
            string WEmail2;
            string WEmail3;


            if (fromEditPage.Firstname != "" && fromEditPage.Lastname != "")
            {
                //  fromEditPage.Firstname=
                FLName = Convert.ToString(fromEditPage.Firstname + " " + fromEditPage.Lastname).Trim();
            }
            else
            {
                FLName = "";
            }

            if (fromEditPage.Firstname != "" && fromEditPage.Lastname == "")
            {

                FLName = Convert.ToString(fromEditPage.Firstname).Trim();
            }
            if (fromEditPage.Firstname == "" && fromEditPage.Lastname != "")
            {

                FLName = Convert.ToString(fromEditPage.Lastname).Trim();
            }

          

            if (fromEditPage.Address != "")
            {
               WAddress= Convert.ToString("\r\n"+fromEditPage.Address);

            }
            else
            {
                WAddress = "";
            }


            if (fromEditPage.Home != "" && fromEditPage.Mobile != "" && fromEditPage.Work != "")
            {
                WHome = Convert.ToString("H: " + fromEditPage.Home + "\r\n" + "M: " + fromEditPage.Mobile + "\r\n" + "W: " + fromEditPage.Work + "\r\n"+ "\r\n").Trim();

            }
            else
            {
                WHome = ""; ;
            }
            if (fromEditPage.Home == "" && fromEditPage.Mobile != "" && fromEditPage.Work != "")
            {
                WHome = Convert.ToString( "M: " + fromEditPage.Mobile + "\r\n" + "W: " + fromEditPage.Work + "\r\n" + "\r\n").Trim();

            }
            if (fromEditPage.Home != "" && fromEditPage.Mobile == "" && fromEditPage.Work != "")
            {
                WHome = Convert.ToString("\r\n" + "H: " + fromEditPage.Home + "\r\n" + "W: " + fromEditPage.Work + "\r\n" + "\r\n").Trim();

            }
            if (fromEditPage.Home != "" && fromEditPage.Mobile != "" && fromEditPage.Work == "")
            {
                WHome = Convert.ToString("\r\n" + "H: " + fromEditPage.Home + "\r\n" + "M: " + fromEditPage.Mobile + "\r\n" + "\r\n").Trim();

            }

            if (fromEditPage.Home != "" && fromEditPage.Mobile =="" && fromEditPage.Work == "")
            {
                WHome = Convert.ToString("\r\n" + "H: " + fromEditPage.Home  + "\r\n" + "\r\n").Trim();

            }
           
            if (fromEditPage.Home == "" && fromEditPage.Mobile != "" && fromEditPage.Work == "")
            {
                WHome = Convert.ToString("\r\n" + "M: " + fromEditPage.Mobile + "\r\n" + "\r\n").Trim();

            }
            if (fromEditPage.Home == "" && fromEditPage.Mobile == "" && fromEditPage.Work != "")
            {
                WHome = Convert.ToString("\r\n" + "W: " + fromEditPage.Work + "\r\n" + "\r\n").Trim();

            }
          

            if (fromEditPage.Email != "" && fromEditPage.Email2 != "" && fromEditPage.Email3 != "")
            {
                WEmail = Convert.ToString(fromEditPage.Email+ "\r\n" + fromEditPage.Email2+ "\r\n" + fromEditPage.Email3).Trim();

            }
            else
            {
                WEmail = null;
            }


            if (fromEditPage.Email == "" && fromEditPage.Email2 != "" && fromEditPage.Email3 != "")
            {
                WEmail = Convert.ToString( fromEditPage.Email2 + "\r\n" + fromEditPage.Email3).Trim();

            }

            if (fromEditPage.Email != "" && fromEditPage.Email2 == "" && fromEditPage.Email3 != "")
            {
                WEmail = Convert.ToString(fromEditPage.Email + "\r\n" + fromEditPage.Email3).Trim();

            }
            if (fromEditPage.Email != "" && fromEditPage.Email2 != "" && fromEditPage.Email3 == "")
            {
                WEmail = Convert.ToString(fromEditPage.Email + "\r\n" + fromEditPage.Email2).Trim();

            }
            if (fromEditPage.Email != "" && fromEditPage.Email2 == "" && fromEditPage.Email3 == "")
            {
                WEmail = Convert.ToString(fromEditPage.Email).Trim();

            }
            if (fromEditPage.Email == "" && fromEditPage.Email2 != "" && fromEditPage.Email3 == "")
            {
                WEmail = Convert.ToString(fromEditPage.Email2).Trim();

            }
            if (fromEditPage.Email == "" && fromEditPage.Email2 == "" && fromEditPage.Email3 != "")
            {
                WEmail = Convert.ToString(fromEditPage.Email3).Trim();

            }

            string EditList =(FLName + WAddress + "\r\n"+ "\r\n" +  WHome + "\r\n" + "\r\n" + WEmail).Trim();

            // Assert.AreEqual(fromTable,fromForm);
            // Assert.AreEqual(fromTable.Address, fromForm.Address);

            //Assert.AreEqual(fromTable.allPhones, fromForm.allPhones);
            // Assert.AreEqual(fromTable.allEmails, fromForm.allEmails);


            Assert.AreEqual(fromDetails,EditList);
            


        }
    }
}
