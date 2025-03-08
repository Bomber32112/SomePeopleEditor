using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SomePeopleEditor.Models
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit(object item)
        {
            InitializeComponent();
            var ListViewStyle = FindResource("ListViewStyle");
            
            Content = item;
        }

        private void RemoveStudent(object sender, RoutedEventArgs e)
        {
            int index = ((Group)DataBase.DB.Item).Students.IndexOf((Student)((Button)sender).Tag);
            ((Group)DataBase.DB.Item).Students.RemoveAt(index);
        }

        private void SaveGroup(object sender, RoutedEventArgs e)
        {
            Group thisGroup = (Group)DataBase.DB.Item;
            if (thisGroup.CuratorOfThisGroup == null || thisGroup.Students == null || thisGroup.Number == 0) 
            {
                MessageBox.Show("Wrong value");
                return;
            }
            if (!DataBase.DB.Groups.Contains(thisGroup))
                DataBase.DB.Groups.Add(thisGroup);
            this.Close();
        }
        private void SaveStudent(object sender, RoutedEventArgs e)
        {
            if (!DataBase.DB.AllStudents.Contains((Student)DataBase.DB.Item))
                DataBase.DB.AllStudents.Add((Student)DataBase.DB.Item);
            this.Close();
        }
        private void SaveCurator(object sender, RoutedEventArgs e)
        {
            if (!DataBase.DB.Curators.Contains((Curator)DataBase.DB.Item))
                DataBase.DB.Curators.Add((Curator)DataBase.DB.Item);
            this.Close();
        }
        private void AddStudent(object sender, RoutedEventArgs e)
        {
            if (!((Group)DataBase.DB.Item).Students.Contains((Student)((Button)sender).Tag))
            ((Group)DataBase.DB.Item).Students.Add((Student)((Button)sender).Tag);
        }
    }
}
