using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook_web_main
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
       // private string name;
       // private string header = "";
       // private string footer = "";
        public GroupData(string name)
        {
            Name = name;

        }
        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other, null))//если тот обьект с которым мы сравниваем равен нул то возвращаем фолсе
            {
                return false;

            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name ==other.Name;
        }
    
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return ("name=" + Name + "\nheader=" + Header + "\nfooter=" +Footer);
        }

        public int CompareTo(GroupData other)
        {
            if(object.ReferenceEquals(other,null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }
        public string Name { get; set; }

        public string Header { get; set; }
     

        public string Footer { get; set; }

        public string Id { get; set; }
    
     
     
    }
}
