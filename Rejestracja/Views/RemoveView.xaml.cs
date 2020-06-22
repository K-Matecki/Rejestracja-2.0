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
using Rejestracja.ViewModels;
namespace Rejestracja.Views
{
    /// <summary>
    /// Logika interakcji dla klasy RemovePerson.xaml
    /// </summary>
    public partial class RemoveView : Page 
    {
        //private List<Appointment> AppointmentList = new List<Appointment>();
        //private List<Person> PersonList = new List<Person>();
   
      
        public RemoveView(int MenuID)
        {
            InitializeComponent();
            this.DataContext = new RemoveViewModel(MenuID); 
        }

    }
}
