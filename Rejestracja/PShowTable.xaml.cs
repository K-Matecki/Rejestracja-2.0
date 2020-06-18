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
    /// Logika interakcji dla klasy ShowPersonTable.xaml
    /// </summary>
    public partial class PShowTable : Page
    {
        int Menu;
        private List<Person> PersonList = new List<Person>();
        public PShowTable()
        {
            InitializeComponent();
        }
        public PShowTable(int MenuId):this()
        {
            Menu = MenuId;
            var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);
            ComboBoxShow.ItemsSource = ValuesPerson.Item1;
            PersonList = ValuesPerson.Item2;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Person> PersonInfo = new List<Person>();
            //mocno skrócić łamie dry
            //znajdź błąd w UpdateAppointments
            if (Menu == 4)
            {
                Patient SelectedPerson = (Patient)PersonList[ComboBoxShow.SelectedIndex];
                PersonInfo.Add(SelectedPerson);
                PersonTable.ItemsSource = PersonInfo;
                SelectedPerson.UpdateAppointments();
                AppointmentsTable.Visibility = Visibility.Visible;
                if ( SelectedPerson.PatientAppointments.Count != 0)
                    AppointmentsTable.ItemsSource = SelectedPerson.PatientAppointments; 
                else
                    AppointmentsTable.Visibility = Visibility.Collapsed;
            }
            else 
            {
                Doctor SelectedPerson = (Doctor)PersonList[ComboBoxShow.SelectedIndex];
                PersonInfo.Add(SelectedPerson);
                PersonTable.ItemsSource = PersonInfo;
                SelectedPerson.UpdateAppointments();
                
                if (SelectedPerson.DoctorAppointment.Count != 0)
                    AppointmentsTable.ItemsSource = SelectedPerson.DoctorAppointment;
                else
                    AppointmentsTable.Visibility = Visibility.Collapsed;
            }
            

        }

    }
}
