using GalaSoft.MvvmLight.Messaging;
using Rejestracja.Models;
using System.Collections.Generic;
using System.Windows.Input;
namespace Rejestracja.ViewModels
{
    class RemoveViewModel : ViewModelBase
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
            RemoveComand = new RelayCommand(Remove, CanBeRemove);
            Index = -1;
        }
        private void Update()
        {
            var ValuesAppointment = DataBase.GetComboBoxListAppointment(Menu);
            var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);

            if (Menu == 10)
            {

                ComboBoxRemove = ValuesAppointment.Item1;
                AppointmentList = ValuesAppointment.Item2;
            }
            else
            {
                ComboBoxRemove = ValuesPerson.Item1;
                PersonList = ValuesPerson.Item2;
            }
        }
        private void Remove()
        {
            string TextMessage = "";
            switch (Menu)
            {
                case 2:
                case 6:
                    if (PersonList[Index].Remove())
                        TextMessage = $"Usunięto {PersonList[Index].Name} {PersonList[Index].Surname}";
                    break;
                case 10:
                    if (AppointmentList[Index].Remove())
                        TextMessage = $"Usunięto termin z dnia: {AppointmentList[Index].AppointmentDate.ToString()}";
                    break;
            }
            Messenger.Default.Send<MyMessage>(new MyMessage { MessageText = TextMessage });
            Update();

        }
        private bool CanBeRemove()
        {
            if (Index < 0)
                return false;

            return Menu == 10 ? Index <= AppointmentList.Count : Index <= PersonList.Count;
        }



    }
}
