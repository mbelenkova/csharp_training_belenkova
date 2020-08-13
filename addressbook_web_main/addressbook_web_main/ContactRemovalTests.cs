using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    { 
        [Test]
        public void ContactRemovalTestsm()
        {
         
            app.ContactH.ContactRemover();
        }
    }
}