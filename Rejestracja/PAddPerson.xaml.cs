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
    /// Logika interakcji dla klasy AddPerson.xaml
    /// </summary>
    public partial class PAddPerson : Page
    {
        private Person NewPerson;
        bool child;
        public PAddPerson()
        {
            InitializeComponent();

        }
        public PAddPerson(int MenuID):this()
        {
            child = MenuID == 1 ? true : false;


        }
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
           NewPerson = child == true ? NewPerson = new Patient(NameText.Text, SurnameText.Text, PeselText.Text) : NewPerson = new Doctor(NameText.Text, SurnameText.Text, PeselText.Text);
           // NewPerson.UpdateAppointments();
            
        }

       
    }
}
