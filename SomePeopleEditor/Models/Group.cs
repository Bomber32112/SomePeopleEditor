using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SomePeopleEditor.Models
{
    public class Group
    {
        int number;
        public int Number 
        {
            get => number;
            set 
            {
                number = value;
                foreach (var item in DataBase.DB.Groups)
                {
                    if (item.Number == Number)
                    {
                        MessageBox.Show("A group with that number already exists");
                        number = 0;
                        return;
                    }
                }
                
            } 
        }
        public Curator CuratorOfThisGroup { get; set; }
        public ObservableCollection<Student> Students { get; set; } = new();
    }
}
