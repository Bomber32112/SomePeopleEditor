using SomePeopleEditor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SomePeopleEditor
{
    public class DataBase: INotifyPropertyChanged
    {
        private object items;
        private object item;
        public object Items
        {
            get => items;
            set
            {
                items = value;
                Signal();
            }
        }
        public object Item
        {
            get => item;
            set
            {
                item = value;
                Signal();
            }
        }
        public ObservableCollection<Student> AllStudents { get; set; } = new();
        public ObservableCollection<Group> Groups { get; set; } = new();
        public ObservableCollection<Curator> Curators { get; set; } = new();



        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string property = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        static DataBase instance;
        public static DataBase DB 
        {
            get { if (instance != null) return instance; else instance = new DataBase(); return instance;}
        }
    }
}
