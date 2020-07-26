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
            if(DataBase.Open())
            Current.Shutdown();
        }
        private void AppExit(object sender, ExitEventArgs e) 
        {
            DataBase.Close();
        }
    }
}
