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
        private List<Appointment> AppointmentList = new List<Appointment>();
        private List<Person> PersonList = new List<Person>();
        private int Menu;
        public delegate (List<string>, List<object>) MyDelegate(int  menu );
        public PRemove()
        {
            InitializeComponent();
          
        }
        public PRemove(int MenuID):this()
        { 
                   Menu = MenuID;
            UpdateComboBoxRemove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            switch (Menu)
            {
                case 2:
                case 6:
                    if (PersonList[ComboBoxRemove.SelectedIndex].Remove())
                        MessageBox.Show($"Usunięto {PersonList[ComboBoxRemove.SelectedIndex].Name}");
                    break;
                case 10:
                    if (AppointmentList[ComboBoxRemove.SelectedIndex].Remove())
                        MessageBox.Show($"Usunięto termin z dnia: {AppointmentList[ComboBoxRemove.SelectedIndex].AppointmentDate.ToString()}");
                    break;
            }
           
            UpdateComboBoxRemove();
            
        }
        private void UpdateComboBoxRemove()
        {
            var ValuesAppointment = DataBase.GetComboBoxListAppointment(Menu);
            var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);
            if (Menu == 10)
            {
                ComboBoxRemove.ItemsSource = ValuesAppointment.Item1;
                AppointmentList = ValuesAppointment.Item2;
            }
            else 
            {
                ComboBoxRemove.ItemsSource = ValuesPerson.Item1;
                PersonList = ValuesPerson.Item2;
            }
           
        }
    }
}
