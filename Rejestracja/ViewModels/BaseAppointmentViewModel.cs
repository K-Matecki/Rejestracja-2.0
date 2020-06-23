using System;
namespace Rejestracja.ViewModels
{
    public abstract class BaseAppointmentViewModel : ViewModelBase
    {

        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        protected DateTime DateToAdd
        {
            get { return Convert.ToDateTime($"{Date.ToString().Remove(10)} {Time.TimeOfDay}"); }
        }
        public BaseAppointmentViewModel()
        {
            Date = DateTime.Now;
            Time = DateTime.Now;
        }

    }
}
