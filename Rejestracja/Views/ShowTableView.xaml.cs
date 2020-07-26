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
using GalaSoft.MvvmLight.Messaging;
using Rejestracja.ViewModels;
namespace Rejestracja.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ShowPersonTable.xaml
    /// </summary>
    public partial class ShowPersonTableView : Page
    {
         
        public ShowPersonTableView(int MenuId) 
         {
            InitializeComponent();
            this.DataContext=new ShowPersonTableViewModel(MenuId);
           
        }

        private void AppointmentsTablePatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
