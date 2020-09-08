using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_main
{
    public class TestBase
    {



        protected ApplicationManager app;


        [SetUp]
        public void SetupApplicationManager()
        {

            app = ApplicationManager.GetInstance();
         

        }

        public static Random rnd = new Random();
       // public static Random rndco = new Random();
        
        public static string GenerateRandomString(int v)
        {
            //делаем генератор случайных чисел
            
            int l = Convert.ToInt32(rnd.NextDouble() * v);
            StringBuilder builder = new StringBuilder();

            for (int i =0; i<l;i++)
            {
              builder.Append(Convert.ToChar(32+ Convert.ToInt32(rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }


       /* public static string GenerateRandomStringCo(int c)
        {
           
            int lc = Convert.ToInt32(rndco.NextDouble() * c);
            StringBuilder builderc = new StringBuilder();

            for (int i = 0; i < lc; i++)
            {

                builderc.Append(Convert.ToChar(Convert.ToInt32(rndco.NextDouble() * 223 + 32)));
            }

            return builderc.ToString();


        }
       */



    }
}