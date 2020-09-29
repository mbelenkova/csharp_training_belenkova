using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackUpFile("/config_inc.php");
            app.Ftp.Upload("/config_inc.php", null);
          

        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"

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
