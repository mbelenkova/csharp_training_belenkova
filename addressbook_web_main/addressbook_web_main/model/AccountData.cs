using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_main
{
   public  class AccountData
    {
        private string username;
        private string password;

        // делаем конструктор
        public AccountData(string username, string password)
        {
                this.username = username;
                this.password = password;
        }
    //делаем свойство для каждого
    public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

    public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password= value;
            }
        }
    }
}
