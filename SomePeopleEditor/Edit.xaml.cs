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

            DataContext = DataBase.DB;
            Content = item;
        }

        private void RemoveStudent(object sender, RoutedEventArgs e)
        {
            int index = ((Group)DataBase.DB.Item).Students.IndexOf(((Student)((Button)sender).Tag));
            ((Group)DataBase.DB.Item).Students.RemoveAt(index);
        }
    }
}
