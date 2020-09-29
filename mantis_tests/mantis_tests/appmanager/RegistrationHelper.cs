﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mantis_tests
{
  public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

     
        internal void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();

            
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.ClassName("back-to-login-link pull-left")).Click();
        }

        private void SubmitRegistration()
        {
            throw new NotImplementedException();
        }

        private void FillRegistrationForm(AccountData  account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.24.3/login_page.php";
        }
    }
}
