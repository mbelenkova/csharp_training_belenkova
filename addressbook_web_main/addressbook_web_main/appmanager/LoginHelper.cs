﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{
   public class LoginHelper: HelperBase
    {
        

        public LoginHelper(ApplicationManager manager): base(manager)
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
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);

        
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

      
        public void Logout()
        {
            if(IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
           
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            //создаем специальный метод, который будет из пользовательского интерфейса вытягивать имя пользователя, который сейчас залогинен

            return IsLoggedIn()
                && GetLoggedUserName() == account.Username;


                
        }

        private string GetLoggedUserName()
        {

            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            //вырежем кусок строки
            return text.Substring(1, text.Length - 2);

        }
    }

   
}
