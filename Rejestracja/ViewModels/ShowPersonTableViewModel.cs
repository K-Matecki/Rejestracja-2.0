using Rejestracja.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace Rejestracja.ViewModels
{
    class ShowPersonTableViewModel : ViewModelBase
    {
        private int Menu;
        private List<Person> PersonList = new List<Person>();
        private List<Person> _selectedPerson;
        private List<Appointment> _appointmentList;
        private bool[] _shouldBeVisible;

        public List<string> ComboBoxPerson { get; private set; }
        public ICommand SelectionChangedCommand { get; }

        public int Index { get; set; }
        public bool[] ShouldBeVisible { get { return _shouldBeVisible; } set { _shouldBeVisible = value; OnPropertyChanged(); } }

        public List<Person> SelectedPerson { get { return _selectedPerson; } set { _selectedPerson = value; OnPropertyChanged(); } }
        public List<Appointment> AppointmentList { get { return _appointmentList; } set { _appointmentList = value; OnPropertyChanged(); } }


        public ShowPersonTableViewModel(int MenuID)
        {
            Menu = MenuID;
            var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);
            ComboBoxPerson = ValuesPerson.Item1;
            PersonList = ValuesPerson.Item2;

            SelectionChangedCommand = new RelayCommand(Change);
            SelectedPerson = new List<Person>();
            ShouldBeVisible = new bool[2];

            if (MenuID == 4)
            {
                ShouldBeVisible[0] = false;
                ShouldBeVisible[1] = true;
            }
            else
            {
                ShouldBeVisible[0] = true;
                ShouldBeVisible[1] = false;
            }
            Index = -1;


        }

        private void Change()
        {
            SelectedPerson = new List<Person>();
            SelectedPerson.Add(PersonList[Index]);
            SelectedPerson[0].UpdateAppointments();
            if (Menu == 4)
                AppointmentList = (SelectedPerson[0] as Patient).PatientAppointments;
            else
                AppointmentList = (SelectedPerson[0] as Doctor).DoctorAppointment;

            if (AppointmentList.Count == 0)
            {
                ShouldBeVisible[0] = false;
                ShouldBeVisible[1] = false;
            }

        }
    }
}
