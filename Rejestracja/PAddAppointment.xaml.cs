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

namespace Rejestracja
{
    /// <summary>
    /// Logika interakcji dla klasy AddAppointment.xaml
    /// </summary>
    public partial class PAddAppointment : Page
    {
        public PAddAppointment()
        {
            InitializeComponent();
            DatapickerAdd.BlackoutDates.AddDatesInPast();
            DatapickerAdd.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
