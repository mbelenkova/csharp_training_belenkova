using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_main
{
   public class GroupTestBase: AuthTestBase
    {
        [TearDown]
        public void CompareGroupUIDB()
        {
            if(PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> FromUI = app.GruopH.GetGroupList();
                List<GroupData> FromDB = GroupData.GetAll();
                FromUI.Sort();
                FromDB.Sort();
                Assert.AreEqual(FromUI, FromDB);
            }

           
        }

    }
}
