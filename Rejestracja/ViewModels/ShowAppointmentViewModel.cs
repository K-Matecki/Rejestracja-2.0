using Rejestracja.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
namespace Rejestracja.ViewModels
{
    public class ShowAppointmentViewModel : ViewModelBase
    {
   
        private List<Appointment> AllAppointmentList;
        private List<Appointment> _appointmentList;
        public List<Appointment> AppointmentList { get { return _appointmentList; } set { _appointmentList = value; OnPropertyChanged(); } }
        private DateTime _selectedDate;
        public DateTime SelectedDate { get { return _selectedDate; } set { _selectedDate = value; DataChange(); } }
        public ICommand DateChangedCommand { get; }
       
        
        public ShowAppointmentViewModel(int MenuId)
        { 
            var ValuesAppointment = DataBase.GetComboBoxListAppointment(MenuId);
            AllAppointmentList = ValuesAppointment.Item2;
           SelectedDate = DateTime.Today;
        }
        
        private void DataChange()
        {
            AppointmentList = new List<Appointment>();
            foreach (var date in AllAppointmentList)
            {
                if (date.AppointmentDate.Date == SelectedDate.Date)
                    AppointmentList.Add(date);
            }
            
        }
    }
}
