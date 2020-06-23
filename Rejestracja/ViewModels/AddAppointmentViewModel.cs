using System.Collections.Generic;
using Rejestracja.Models;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace Rejestracja.ViewModels
{
    public class AddAppointmentViewModel : BaseAppointmentViewModel
    {
        private List<Doctor> DoctorList = new List<Doctor>();
        private List<Patient> PatientList = new List<Patient>();
        public List<string> ComboBoxPatient { get; private set; }
        public List<string> ComboBoxDoctor { get; private set; }
        public int IndexDoctor { get; set ; } 
        public int IndexPatient { get; set; }
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

            IndexDoctor = -1;
            IndexPatient = -1;
        }
        private void Add()
        {
            NewAppointment = new Appointment(DateToAdd, DoctorList[IndexDoctor], PatientList[IndexPatient]);
            Messenger.Default.Send<MyMessage>(new MyMessage { MessageText = "Pomyślnie dodano termin" }); 
        }
        private bool CanAddAppointment()
        {
            if (IndexDoctor == -1 || IndexPatient == -1)
                return false;
            return IndexDoctor  <=  DoctorList.Count - 1 && IndexPatient <= PatientList.Count - 1;
        }
    

    }
}
