﻿using System;
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
    public class GroupRemovalTests : TestBase
    {
        [Test]

        public void GroupRemovalTestsm()
        {

            app.GruopH.Remove();
        }

    }

   


}

    
       

       