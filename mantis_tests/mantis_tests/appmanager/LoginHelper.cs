﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
  public  class LoginHelper: HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {

        }


        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            //login
            Type(By.Name("username"), account.Name);

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

            Type(By.Name("password"), account.Password);


            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/i[2]")).Click();
                driver.FindElement(By.LinkText("Logout")).Click();
            }

        }
        public bool IsLoggedIn()
        {
           // return IsElementPresent(By.Name("Logout"));

            return IsElementPresent(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/span"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            //создаем специальный метод, который будет из пользовательского интерфейса вытягивать имя пользователя, который сейчас залогинен

            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;



        }

        private string GetLoggedUserName()
        {

           // string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;

            string text = driver.FindElement(By.CssSelector("span.user-info")).Text;
            //вырежем кусок строки
            // return text.Substring(1, text.Length - 2);
            return text;

        }
    }
}
