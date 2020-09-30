using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackUpFile("/config_inc.php");
            using (Stream localFile = File.Open(TestContext.CurrentContext.TestDirectory + "\\config_inc.php", FileMode.Open)) // File.Open(TestContext.CurrentContext.TestDirectory + "\\config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);

            }
           
          

        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData("testuser", "password")
            {
              
                Email = "testuser@localhost.localdomainone"

            };

            app.Registration.Register(account);
           
        }

        [OneTimeTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }

    }
}
