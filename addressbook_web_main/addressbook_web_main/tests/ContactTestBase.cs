using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_main
{
  public  class ContactTestBase: AuthTestBase
    {
        [TearDown]
        public void CompareContactUIDB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> FromUI = app.ContactH.GetContactList();
                List<ContactData> FromDB = ContactData.GetAll();
                FromUI.Sort();
                FromDB.Sort();
                Assert.AreEqual(FromUI, FromDB);

            }

            
        }

    }
}
