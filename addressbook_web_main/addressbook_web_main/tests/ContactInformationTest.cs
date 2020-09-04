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

            if (fromEditPage.Firstname != null && fromEditPage.Lastname!=null)
            {
              //  fromEditPage.Firstname=
               FLName = Convert.ToString(fromEditPage.Firstname + " " + fromEditPage.Lastname );
            }
            else
            {
                 FLName = "";
            }


            if (fromEditPage.Firstname != null && fromEditPage.Lastname == null)
            {

                FLName = Convert.ToString(fromEditPage.Firstname+ "\r\n");
            }
            if (fromEditPage.Firstname == null && fromEditPage.Lastname != null)
            {

                FLName = Convert.ToString(fromEditPage.Lastname+ "\r\n");
            }


            if (fromEditPage.Address != null)
            {
               WAddress= Convert.ToString("\r\n"+fromEditPage.Address);

            }
            else
            {
                WAddress = "";
            }


            if (fromEditPage.Home != null && fromEditPage.Mobile != null && fromEditPage.Work != null)
            {
                WHome = Convert.ToString("H: "+ fromEditPage.Home + "\r\n"+"M: " + fromEditPage.Mobile + "\r\n"+ "W: " + fromEditPage.Work);

            }
            else
            {
                WHome = "";
            }
            if (fromEditPage.Home == null && fromEditPage.Mobile != null && fromEditPage.Work != null)
            {
                WHome = Convert.ToString("M: " + fromEditPage.Mobile + "\r\n" + "W: " + fromEditPage.Work);

            }
            if (fromEditPage.Home != null && fromEditPage.Mobile == null && fromEditPage.Work != null)
            {
                WHome = Convert.ToString("H: " + fromEditPage.Home + "\r\n" + "W: " + fromEditPage.Work);

            }
            if (fromEditPage.Home != null && fromEditPage.Mobile != null && fromEditPage.Work == null)
            {
                WHome = Convert.ToString("H: " + fromEditPage.Home + "\r\n" + "M: " + fromEditPage.Mobile );

            }


            if (fromEditPage.Email != null && fromEditPage.Email2 != null&& fromEditPage.Email3 != null)
            {
                WEmail = Convert.ToString(fromEditPage.Email+ "\r\n" + fromEditPage.Email2+ "\r\n" + fromEditPage.Email3);

            }
            else
            {
                WEmail = "";
            }


            if (fromEditPage.Email == null && fromEditPage.Email2 != null && fromEditPage.Email3 != null)
            {
                WEmail = Convert.ToString( fromEditPage.Email2 + "\r\n" + fromEditPage.Email3);

            }

            if (fromEditPage.Email != null && fromEditPage.Email2 == null && fromEditPage.Email3 != null)
            {
                WEmail = Convert.ToString(fromEditPage.Email + "\r\n" + fromEditPage.Email3);

            }
            if (fromEditPage.Email != null && fromEditPage.Email2 != null && fromEditPage.Email3 == null)
            {
                WEmail = Convert.ToString(fromEditPage.Email + "\r\n" + fromEditPage.Email2);

            }

            string EditList =(FLName + WAddress + "\r\n" + "\r\n"+ WHome + "\r\n"+ "\r\n" + WEmail).Trim();

            // Assert.AreEqual(fromTable,fromForm);
            // Assert.AreEqual(fromTable.Address, fromForm.Address);

            //Assert.AreEqual(fromTable.allPhones, fromForm.allPhones);
            // Assert.AreEqual(fromTable.allEmails, fromForm.allEmails);


            Assert.AreEqual(fromDetails,EditList);
            


        }
    }
}
