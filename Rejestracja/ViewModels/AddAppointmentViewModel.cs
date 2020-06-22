using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rejestracja.Models;
using System.Windows.Input;
using System.Windows;

namespace Rejestracja.ViewModels
{
    public class AddAppointmentViewModel : BaseAppointmentViewModel
    {
        private List<Doctor> DoctorList = new List<Doctor>();
        private List<Patient> PatientList = new List<Patient>();
        public List<string> ComboBoxPatient { get; private set; }
        public List<string> ComboBoxDoctor { get; private set; }
        public int IndexDoctor { get; set ; } // <  OnPropertyChanged();
        public int IndexPatient { get; set; } // <  OnPropertyChanged();
        private Appointment NewAppointment;
        public ICommand AddAppointmentCommand { get; }

        public AddAppointmentViewModel( ):base()
        {
            var ValuesPerson = DataBase.GetComboBoxListPerson(2);
            ComboBoxPatient= ValuesPerson.Item1;
            
            foreach (var item in ValuesPerson.Item2)
                PatientList.Add((Patient)item);

            ValuesPerson = DataBase.GetComboBoxListPerson(6);
            ComboBoxDoctor = ValuesPerson.Item1;

            foreach (var item in ValuesPerson.Item2)
                DoctorList.Add((Doctor)item);

            AddAppointmentCommand = new RelayCommand(Add, CanAddAppointment);
        }
        private void Add()
        {
            NewAppointment = new Appointment(DateToAdd, DoctorList[IndexDoctor], PatientList[IndexPatient]);
            MessageBox.Show("Pomyślnie dodano termin");
        }
        private bool CanAddAppointment()
        {
            return IndexDoctor  <=  DoctorList.Count - 1 && IndexPatient <= PatientList.Count - 1;
        }
    

    }
}
