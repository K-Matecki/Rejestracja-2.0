using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rejestracja.Models;
using Caliburn.Micro;
using System.Windows.Input;
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
