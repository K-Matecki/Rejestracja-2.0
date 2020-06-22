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
    /// Logika interakcji dla klasy ShowPersonTable.xaml
    /// </summary>
    public partial class ShowTableView : Page
    {
        int Menu;
          //private List<Person> PersonList = new List<Person>();
         public ShowTableView()
         {
             InitializeComponent();
         }
         public ShowTableView(int MenuId):this()
         {
             Menu = MenuId;
            /* var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);
             ComboBoxShow.ItemsSource = ValuesPerson.Item1;
             PersonList = ValuesPerson.Item2;
             */
         }

         private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
            /* List<Person> PersonInfo = new List<Person>();
             //mocno skrócić łamie dry
             //znajdź błąd w UpdateAppointments
             if (Menu == 4)
             {
                 Patient SelectedPerson = (Patient)PersonList[ComboBoxShow.SelectedIndex];
                 PersonInfo.Add(SelectedPerson);
                 PersonTable.ItemsSource = PersonInfo;
                 SelectedPerson.UpdateAppointments();
                 AppointmentsTablePatient.Visibility = Visibility.Collapsed;
                 AppointmentsTablePatient.Visibility = Visibility.Visible;
                 if ( SelectedPerson.PatientAppointments.Count != 0)
                     AppointmentsTablePatient.ItemsSource = SelectedPerson.PatientAppointments; 
                 else
                     AppointmentsTablePatient.Visibility = Visibility.Collapsed;
             }
             else 
             {
                 Doctor SelectedPerson = (Doctor)PersonList[ComboBoxShow.SelectedIndex];
                 PersonInfo.Add(SelectedPerson);
                 PersonTable.ItemsSource = PersonInfo;
                 SelectedPerson.UpdateAppointments();

                 if (SelectedPerson.DoctorAppointment.Count != 0)
                     AppointmentsTableDoctor.ItemsSource = SelectedPerson.DoctorAppointment;
                 else
                     AppointmentsTableDoctor.Visibility = Visibility.Collapsed;
             }

            */
         }
         
    }
}
