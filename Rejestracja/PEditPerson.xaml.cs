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
    /// Logika interakcji dla klasy EditPerson.xaml
    /// </summary>
    public partial class PEditPerson : Page
    {
        private int Menu;
        private List<Person> PersonList = new List<Person>();
        public PEditPerson()
        {
            InitializeComponent();
        }
        public PEditPerson(int MenuID) : this()
        {
            Menu = MenuID;
            var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);
            ComboBoxEdit.ItemsSource = ValuesPerson.Item1;
            PersonList = ValuesPerson.Item2;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            NameText.Text =  PersonList[ComboBoxEdit.SelectedIndex].Name;
            SurnameText.Text =  PersonList[ComboBoxEdit.SelectedIndex].Surname;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Message;
            Message=  PersonList[ComboBoxEdit.SelectedIndex].Edit(NameText.Text, SurnameText.Text) ? "Pomyślnie edytowano osobe":"Nie udało sie edytować osoby";
            MessageBox.Show(Message);
 
        }
         
    }
}