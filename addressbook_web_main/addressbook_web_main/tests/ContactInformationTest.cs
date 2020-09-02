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

            Assert.AreEqual(fromTable,fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.allPhones, fromForm.allPhones);
            Assert.AreEqual(fromTable.allEmails, fromForm.allEmails);




        }
    }
}
