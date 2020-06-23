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
    class RemoveViewModel :ViewModelBase
    {
        private int Menu;
        private List<Appointment> AppointmentList = new List<Appointment>();
        private List<Person> PersonList = new List<Person>();
        public int Index { get; set; }
        public ICommand RemoveComand { get; }
        private List<string> _comboBoxRemove;
        public List<string> ComboBoxRemove
        {
            get
            {
                return _comboBoxRemove;
            }
            private set
            {
                _comboBoxRemove = value;
                OnPropertyChanged();
            }
        }

        public RemoveViewModel(int MenuID)
        {
            Menu = MenuID;
            Update();
            RemoveComand= new RelayCommand(Remove, CanRemove);
            Index = -1;
        }
        private void Update() 
        {
            var ValuesAppointment = DataBase.GetComboBoxListAppointment(Menu);
            var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);
            
            if (Menu == 10)
            {

                ComboBoxRemove  = ValuesAppointment.Item1;
                AppointmentList = ValuesAppointment.Item2;
            }
            else 
            {
                ComboBoxRemove  = ValuesPerson.Item1;
                PersonList = ValuesPerson.Item2;
            }
        }
        private void Remove()
        {
            switch (Menu)
            {
                case 2:
                case 6:
                    if (PersonList[Index].Remove())
                        MessageBox.Show($"Usunięto {PersonList[Index].Name} {PersonList[Index].Surname}");
                    break;
                case 10:
                    if (AppointmentList[Index].Remove())
                        MessageBox.Show($"Usunięto termin z dnia: {AppointmentList[Index].AppointmentDate.ToString()}");
                    break;
            }
            Update();

        }
        private bool CanRemove() 
        {
            return Index > -1 && Menu ==10? Index <= AppointmentList.Count : Index <= PersonList.Count; 
        }

         
    }
}
