using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using Rejestracja.ViewModels;

namespace Rejestracja.Views
{
    /// <summary>
    /// Logika interakcji dla klasy EditAppointment.xaml
    /// </summary>
    public partial class EditAppointmentView : Page  
    {
         
        public EditAppointmentView(int MenuId) 
        {
            InitializeComponent();
            //IEventAggregator events = new EventAggregator();
            this.DataContext = new EditAppointmentViewModel(MenuId);
            
        }
 
    }
}
  