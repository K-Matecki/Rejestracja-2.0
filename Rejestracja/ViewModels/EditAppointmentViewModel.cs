using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using Rejestracja.Models;
namespace Rejestracja.ViewModels
{//, IHandle<string>
    class EditAppointmentViewModel : BaseAppointmentViewModel
    {
        // private readonly IEventAggregator _aggregator;
        // private string _text;
        private int menu;
        public int Index { get; set; }
        private List<Appointment> AppointmentList = new List<Appointment>();
        
        public List<string> _comboBoxAppointment;
        public List<string> ComboBoxAppointment {
            get { 
             return _comboBoxAppointment; 
            }
            private set {
                _comboBoxAppointment = value;
                OnPropertyChanged();
            }
        }
       
        public ICommand EditCommand { get;}


        /* public string Text
         {
              get { return _text; }
              set
              {
                  _text = value;
                  OnPropertyChanged();
              }
         }
         , IEventAggregator aggregator*/
        public EditAppointmentViewModel(int MenuId) : base() 
        {
            menu = MenuId;
            Update();
            EditCommand = new RelayCommand(Edit, CanEditAppointment);
            Index = -1;
            //_aggregator = aggregator;
            // _aggregator.Subscribe(this);
            
          // BlackoutDates.AddDatesInPast();
           //BlackoutDates.Add(new System.Windows.Controls.CalendarDateRange(DateTime.Now.AddDays(-1)));
           
        }
        private bool CanEditAppointment()
        {
            return Index > -1 && Index  <= AppointmentList.Count;
        }
        private void Edit()
        {
           if( AppointmentList[Index].Edit(DateToAdd))
             MessageBox.Show("Pomyślna Edycja");  
           else
             MessageBox.Show("Nieudana edycja");
            Update();
        }
        private void Update()
        {
            var ValuesAppointment = DataBase.GetComboBoxListAppointment(menu);
            ComboBoxAppointment = ValuesAppointment.Item1;
            AppointmentList = ValuesAppointment.Item2;
        }
        /*
        public void Handle(string message)
        {
            Text = message;
            MessageBox.Show(Text);
        }
        */
    }
}
       