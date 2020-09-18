﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook_web_main
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        // private string name;
        // private string header = "";
        // private string footer = "";

        public GroupData()
        {


        }
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

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return ("name=" + Name + "\nheader=" + Header + "\nfooter=" + Footer);
        }

        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }
        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();


            }
        }
           
        public List <ContactData> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts 
                        from gcr in db.GCR.Where(P=>P.GroupId == Id && P.ContactId ==c.Id && c.Deprecated == "0000-00-00 00:00:00") select c).Distinct().ToList();



            }
        }

    }
}
