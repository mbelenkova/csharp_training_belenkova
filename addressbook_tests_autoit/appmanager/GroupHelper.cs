using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoItX3Lib;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {

        public ApplicationManager manager;

        public static string GROUPWINTITLE = "Group editor";

        public static string GROUPREMOVECONFIRM = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }




        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialog();

        }

   

        public GroupHelper RemoveGroup(int group_to_remove_index)
        {

           aux.ControlTreeView(
                   GROUPWINTITLE
                   , ""
                   , "WindowsForms10.SysTreeView32.app.0.2c908d51"
                   , "Select"
                   , "#0|#" + group_to_remove_index
                   , ""
                   ); 

            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");

            aux.WinWait(GROUPREMOVECONFIRM);
            aux.WinActivate(GROUPREMOVECONFIRM);
            aux.WinWaitActive(GROUPREMOVECONFIRM);

            aux.ControlClick(GROUPREMOVECONFIRM, "", "WindowsForms10.BUTTON.app.0.2c908d53");

            aux.WinWaitClose(GROUPREMOVECONFIRM, "", 10);




            return this;

            //  aux.WinMenuSelectItem(GROUPWINTITLE, "", group_to_remove);

        }

       

        public void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

       public void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);//какое окно ждем
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item

                });
            }
               
                CloseGroupsDialog();
            return list;
        }

      

          
        }
    }


