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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rejestracja
{
    /// <summary>
    /// Logika interakcji dla klasy RemovePerson.xaml
    /// </summary>
    public partial class PRemove : Page
    {
        private List<Person> PersonList = new List<Person>();
        private List<string> StringData = new List<string>();
        public PRemove()
        {
            InitializeComponent();
          
        }
        public PRemove(int MenuID):this()
        {
            switch (MenuID)
            {
                case 2:
                    StringData = DataBase.GetData("select * from patients", "patients");
                    break;
                case 6:
                    StringData = DataBase.GetData("select * from doctors", "doctors");
                    break;
                case 10:
                    StringData = DataBase.GetData("select * from appointments", "appointments");
                    break;
            }

            string[] Line;
            List<string> ComboBoxList = new List<string>();

            foreach (var item in StringData)
            {
                Line = item.Split(',');
                PersonList.Add(new Patient(int.Parse(Line[0]), Line[1], Line[2], Line[3]));
            }
            foreach (var item in PersonList)
            {
                ComboBoxList.Add($"{item.Name} {item.Surname}");
            }


            ComboBoxRemove.ItemsSource = ComboBoxList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(PersonList[ComboBoxRemove.SelectedIndex].Remove())
            MessageBox.Show($"Usunięto {PersonList[ComboBoxRemove.SelectedIndex].Name}");
            PersonList.Remove(PersonList[ComboBoxRemove.SelectedIndex]);
          
        }
    }
}
