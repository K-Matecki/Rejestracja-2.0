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
    /// Logika interakcji dla klasy AddAppointment.xaml
    /// </summary>
    public partial class PAddAppointment : Page
    {
        private List<Doctor> DoctorList = new List<Doctor>();
        private List<Patient> PatientList = new List<Patient>();
        public PAddAppointment()
        {
            InitializeComponent();
            DatapickerAdd.BlackoutDates.AddDatesInPast();
            DatapickerAdd.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
           
            ComboBoxPatient.ItemsSource = DataBase.GetComboBoxList(2);
            
            foreach (var item in DataBase.PersonList)
                PatientList.Add((Patient)item);

            
            ComboBoxDoctor.ItemsSource = DataBase.GetComboBoxList(6);
            
            foreach (var item in DataBase.PersonList)
                DoctorList.Add((Doctor)item);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dodać sprawdzanie dostępności terminów
        
            string Date = DatapickerAdd.ToString().Remove(10);
            Date += ClockAdd.Time.ToString().Remove(0,10);
            DateTime AppointmentDate =  Convert.ToDateTime(Date);
            Appointment NewAppointment;
            NewAppointment = new Appointment(AppointmentDate, DoctorList[ComboBoxPatient.SelectedIndex], PatientList[ComboBoxPatient.SelectedIndex]);
        }
        
    }
}
