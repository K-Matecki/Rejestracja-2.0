using GalaSoft.MvvmLight.Messaging;
using Rejestracja.Models;
using System.Collections.Generic;
using System.Windows.Input;
namespace Rejestracja.ViewModels
{

    class EditAppointmentViewModel : BaseAppointmentViewModel
    {
        private int menu;
        public int Index { get; set; }
        private List<Appointment> AppointmentList = new List<Appointment>();

        public List<string> _comboBoxAppointment;
        public List<string> ComboBoxAppointment
        {
            get
            {
                return _comboBoxAppointment;
            }
            private set
            {
                _comboBoxAppointment = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditCommand { get; }

        public EditAppointmentViewModel(int MenuId) : base()
        {
            menu = MenuId;
            Update();
            EditCommand = new RelayCommand(Edit, CanEditAppointment);
            Index = -1;


            // BlackoutDates.AddDatesInPast();
            //BlackoutDates.Add(new System.Windows.Controls.CalendarDateRange(DateTime.Now.AddDays(-1)));

        }
        private bool CanEditAppointment()
        {
            if (Index == -1)
                return false;
            return Index <= AppointmentList.Count - 1;
        }
        private void Edit()
        {
            string TextMessage = "";
            if (AppointmentList[Index].Edit(DateToAdd))
                TextMessage = "Pomyślna Edycja";
            else
                TextMessage = "Nieudana edycja";
            Messenger.Default.Send<MyMessage>(new MyMessage { MessageText = TextMessage });
            Update();
        }
        private void Update()
        {
            var ValuesAppointment = DataBase.GetComboBoxListAppointment(menu);
            ComboBoxAppointment = ValuesAppointment.Item1;
            AppointmentList = ValuesAppointment.Item2;
        }

    }
}
