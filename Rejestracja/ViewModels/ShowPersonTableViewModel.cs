using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Rejestracja.Models;

namespace Rejestracja.ViewModels
{
    class ShowPersonTableViewModel :ViewModelBase 
    {
        private int Menu;
        private List<Person> PersonList = new List<Person>();
        public List<string> ComboBoxPerson { get; private set;}
        private List<Person> ShowList { get; set; }
        public ICommand SelectionChangedCommand { get; }
        public int Index { get; set; }
        private Person _selectedPerson;
        public bool[] ShouldBeVisible { get; set; } 
        public Person SelectedPerson {
            get { return _selectedPerson; }
            set { _selectedPerson = value; 
                OnPropertyChanged(); } 
        }
 

        public List<Appointment> AppointmentList { get; private set; }
         /* public Visibility TableVisibility 
          {
              get { return _shouldBeVisible ? Visibility.Visible : Visibility.Collapsed; }
          }
          public string PatientName { get; private set; }
          public string PatientSurname { get; private set; }
          public string DoctorName { get; private set; }
          public string DoctorSurname { get; private set; }
          public DateTime AppointmentDate { get; private set; }
          */

        public ShowPersonTableViewModel(int MenuID)
        {
            Menu = MenuID;
            var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);
            ComboBoxPerson = ValuesPerson.Item1;
            PersonList = ValuesPerson.Item2;
            SelectionChangedCommand = new RelayCommand(Change);
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
           ShowList = new List<Person>();
            if (Menu == 4)
            {
                 
                SelectedPerson = (Patient)PersonList[Index];
                AppointmentList = (SelectedPerson as Patient).PatientAppointments;
                
                //PersonTable.ItemsSource = PersonInfo;

                // AppointmentsTablePatient.Visibility = Visibility.Collapsed;
                //AppointmentsTablePatient.Visibility = Visibility.Visible;
                //if (SelectedPerson.PatientAppointments.Count != 0)
                // AppointmentsTablePatient.ItemsSource = SelectedPerson.PatientAppointments;
                //else
                // AppointmentsTablePatient.Visibility = Visibility.Collapsed;
            }
            else
            { 
                SelectedPerson = PersonList[Index];
                AppointmentList = (SelectedPerson as Doctor).DoctorAppointment;
                
                //PersonInfo.Add(SelectedPerson);
                // PersonTable.ItemsSource = PersonInfo;


                //if (SelectedPerson.DoctorAppointment.Count != 0)
                //AppointmentsTableDoctor.ItemsSource = SelectedPerson.DoctorAppointment;
                // else
                // AppointmentsTableDoctor.Visibility = Visibility.Collapsed;
            }
            ShowList.Add(SelectedPerson);
            if (AppointmentList.Count == 0)
            {
                ShouldBeVisible[0] = false;
                ShouldBeVisible[1] = false;
            }
                
        }
    }
}
