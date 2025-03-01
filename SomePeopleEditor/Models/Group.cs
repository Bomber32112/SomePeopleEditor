using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePeopleEditor.Models
{
    public class Group
    {
        public int Number { get; set; }
        public ObservableCollection<Student> Students { get; set; } = new();
    }
}
