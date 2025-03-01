using SomePeopleEditor.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SomePeopleEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBase.DB.AllStudents.Add(new Student {Name = "Anton", Surname = "Petrovych", Birthday = new DateTime(2000,2,2), GroupNumber = 1234 });
            DataBase.DB.Groups.Add(new Group { Number = 1234, Students = DataBase.DB.AllStudents });
            DataBase.DB.Curators.Add(new Curator {Name = "Petr", Surname = "Petrovych", GroupNumber = 1234, Subject = "Math" });
            DataContext = DataBase.DB;
        }




        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string property = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        private void GetStudentList(object sender, RoutedEventArgs e)
        {
            DataBase.DB.Items = DataBase.DB.AllStudents;
        }

        private void GetGroupList(object sender, RoutedEventArgs e)
        {
            DataBase.DB.Items = DataBase.DB.Groups;
        }

        private void GetCuratorList(object sender, RoutedEventArgs e)
        {
            DataBase.DB.Items = DataBase.DB.Curators;
        }

        private void EditItem(object sender, RoutedEventArgs e)
        {
            if (DataBase.DB.Item != null) 
                new Edit(DataBase.DB.Item).ShowDialog();
        }
    }
}