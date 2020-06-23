using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using GalaSoft.MvvmLight.Messaging;
using Rejestracja.ViewModels;

namespace Rejestracja.Views
{
    /// <summary>
    /// Logika interakcji dla klasy EditAppointment.xaml
    /// </summary>
    public partial class EditAppointmentView : Page  
    {
        static bool isRegistered = false;
        public EditAppointmentView(int MenuId) 
        {
            InitializeComponent();
            //IEventAggregator events = new EventAggregator();
            this.DataContext = new EditAppointmentViewModel(MenuId);
            if (!isRegistered)
            {
                //Messenger.Default.Register<MyMessage>(this.DataContext, MyMessage.ProcessMessage);
                isRegistered = true;
            }
        }
        
    }
}
  