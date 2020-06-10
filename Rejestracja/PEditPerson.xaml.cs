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
        public PEditPerson()
        {
            InitializeComponent();
        }
        public PEditPerson(int MenuID) : this()
        {
            Menu = MenuID;
            UpdateComboBoxEdit();
           
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            NameText.Text = DataBase.PersonList[ComboBoxEdit.SelectedIndex].Name;
            SurnameText.Text = DataBase.PersonList[ComboBoxEdit.SelectedIndex].Surname;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Message;
            Message= DataBase.PersonList[ComboBoxEdit.SelectedIndex].EditInDatabase(NameText.Text, SurnameText.Text) ? "Pomyślnie edytowano osobe":"Nie udało sie edytować osoby";
            MessageBox.Show(Message);
            // UpdateComboBoxEdit(); //ComboBoxEdit.SelectedIndex zwraca -1 w przypadku pacjenta ??
        }
        private void UpdateComboBoxEdit()
        {
            ComboBoxEdit.ItemsSource = DataBase.GetComboBoxList(Menu);
        }
    }
}