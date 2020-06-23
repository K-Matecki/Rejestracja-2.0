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
using System.ComponentModel;
using Rejestracja.ViewModels;
using GalaSoft.MvvmLight.Messaging;

namespace Rejestracja.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
             InitializeComponent();
            MainWindowViewModel MW = new MainWindowViewModel();

            foreach (var item in MW.ItemMenuList)
            {
                Menu.Children.Add(new UserControlMenuItem(item, this));
            }
            Messenger.Default.Register<MyMessage>(Main, MyMessage.ProcessMessage);
        }

         
        internal void SwitchScreen(int Id)
        {
            
            switch (Id)
            {
                case 1:
                case 5:
                    Main.Content = new AddPersonView(Id);
                  break;
                case 2:
                case 6:
                case 10:
                    Main.Content = new RemoveView(Id);
                    break;
                case 3:
                case 7:
                    Main.Content = new EditPersonView(Id);
                    break;
                case 4:
                case 8:
                     Main.Content = new ShowTableView(Id);
                    break;
                    case 9:
                    Main.Content = new AddAppointmentView();
                    break;
                case 11:
                    Main.Content = new EditAppointmentView(Id);
                    break;
                case 12:
                   // Main.Content
                    break;
               
            }
           
        }

         
     }
}
