using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_main
{

    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTestsm()
        {

            GroupData newData = new GroupData("modifiedData");
            newData.Header = "modifiedData";
            newData.Footer = "modifiedData";

            app.GruopH.ModifyGroup(1, newData);

        }
    }
}
