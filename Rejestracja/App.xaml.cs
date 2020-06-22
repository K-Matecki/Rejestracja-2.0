using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Rejestracja.Models;
namespace Rejestracja
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void AppStartup(object sender, StartupEventArgs args)
        {
            DataBase.Connection.Open();
            if (DataBase.Connection == null || DataBase.Connection.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Nieprawidłowe połączenie z baza");
                Current.Shutdown();
            }
        }
        private void AppExit(object sender, ExitEventArgs e) 
        {
            DataBase.Connection.Close();
        }
    }
}
