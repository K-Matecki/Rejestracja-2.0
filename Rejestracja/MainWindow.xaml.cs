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
using MaterialDesignThemes.Wpf;

namespace Rejestracja
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var MenuPatients = new List<SubItem>();
            MenuPatients.Add(new SubItem("Dodaj pacjenta",1));
            MenuPatients.Add(new SubItem("Usuń pacjenta", 2));
            MenuPatients.Add(new SubItem("Edytuj informacje o pacjęcie",3));
            MenuPatients.Add(new SubItem("Wyświetl wszystkich pacjętów",4));

            var Item0 = new ItemMenu("Pacjent", MenuPatients, PackIconKind.UserHeart);

            var MenuDoctors = new List<SubItem>();
            MenuDoctors.Add(new SubItem("Dodaj lekarza",5));
            MenuDoctors.Add(new SubItem("Usuń lekarza",6));
            MenuDoctors.Add(new SubItem("Edytuj informacje o lekarzu",7));
            MenuDoctors.Add(new SubItem("Wyświetl wszystkich lekarzy",8));
            var Item1 = new ItemMenu("Lekarz", MenuDoctors, PackIconKind.Doctor);

            var MenuApointments = new List<SubItem>();
            MenuApointments.Add(new SubItem("Dodaj termin",9));
            MenuApointments.Add(new SubItem("Usuń termin",10));
            MenuApointments.Add(new SubItem("Edytuj termin",11));
            MenuApointments.Add(new SubItem("Wyświetl wszystkie termin",12));
            var Item2 = new ItemMenu("Termin", MenuApointments, PackIconKind.UserClock);
   
            Menu.Children.Add(new UserControlMenuItem(Item0, this));
            Menu.Children.Add(new UserControlMenuItem(Item1,this));
            Menu.Children.Add(new UserControlMenuItem(Item2, this));
          
        }


       internal void SwitchScreen(int Id)
        {
       
            switch (Id)
            {
                case 1:
                case 5:
                    Main.Content = new PAddPerson();
                  
                    break;
                case 2:
                case 6:
                case 10:
                    Main.Content = new PRemove();
                    break;
                case 3:
                case 7:
                    Main.Content = new PEditPerson();
                    break;
                case 4:
                case 8:
                case 12:
                    Main.Content = new PShowTable();
                    break;
                    case 9:
                    Main.Content = new PAddAppointment();
                    break;
                case 11:
                    Main.Content = new PEditAppointment();
                    break;
            }
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var = NameText.Text;
           
           // MessageBox.Show(Doctor.IsChecked == true ? "u" : "fuck0");
        }

      
       
    }
}
