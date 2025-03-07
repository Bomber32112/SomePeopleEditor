using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SomePeopleEditor.Models
{
    public class Curator
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subject { get; set; }
        int groupNumber;
        public int GroupNumber 
        { 
            get => groupNumber;
            set 
            {
                groupNumber = value;
                foreach (var item in DataBase.DB.Groups)
                {
                    if (item.Number == GroupNumber) 
                    {
                        item.CuratorOfThisGroup = this;
                        return;
                    }
                }
            } 
        }
    }
}
