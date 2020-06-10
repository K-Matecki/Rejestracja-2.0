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
    /// Logika interakcji dla klasy EditAppointment.xaml
    /// </summary>
    public partial class PEditAppointment : Page
    {
        public PEditAppointment()
        {
            InitializeComponent(); DatapickerEdit.BlackoutDates.AddDatesInPast();
            DatapickerEdit.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
            
        }
        public PEditAppointment(int MenuId):this()
        {
            ComboBoxEditA.ItemsSource = DataBase.GetComboBoxList(MenuId);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Message;
            string Date = DatapickerEdit.ToString().Remove(10);
            Date += ClockEdit.Time.ToString().Remove(0, 10);
            DateTime AppointmentDate = Convert.ToDateTime(Date);

            Message = DataBase.AppointmentList[ComboBoxEditA.SelectedIndex].Edit(AppointmentDate) ? "Pomyślnie edytowano Termin" : "Nie udało sie edytować Terminu";
            MessageBox.Show(Message);
        }
    }
}
