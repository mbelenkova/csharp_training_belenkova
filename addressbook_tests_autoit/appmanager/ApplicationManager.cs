using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
       
        private AutoItX3 aux;
        public static string WINTITLE = "Free Address Book";
        private GroupHelper groupHelper;
        
        public ApplicationManager()
        {
            
            aux = new AutoItX3();
            aux.Run(@"C:\Users\Home\Desktop\FreeAddressBookPortable\AddressBook.exe","",aux.SW_SHOW);//первый параметр путь к запускаемому приложению,остальные параметры можно проигнорировать
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);


            groupHelper = new GroupHelper(this);

        }

      
        public void Stop()
        {
            aux.ControlClick(WINTITLE,"", "WindowsForms10.BUTTON.app.0.2c908d510"); // 3 параметра: 1 название окна в котором нужно нажимать кнопку,2 параметр - текст самой кнопки,3 параметр- идентификатор кнопки
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups
        {
            get 
            {
                return groupHelper;
            }
        }

    }
}
