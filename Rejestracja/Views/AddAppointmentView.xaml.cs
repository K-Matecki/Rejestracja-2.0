using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Caliburn.Micro;
using GalaSoft.MvvmLight.Messaging;
using Rejestracja.ViewModels;
namespace Rejestracja.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddAppointment.xaml
    /// </summary>
    public partial class AddAppointmentView : Page
    {
       
        public AddAppointmentView()
        {
            InitializeComponent();
            DatapickerAdd.BlackoutDates.AddDatesInPast();
            DatapickerAdd.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
      
            this.DataContext = new AddAppointmentViewModel();
        }

         


    }
}
