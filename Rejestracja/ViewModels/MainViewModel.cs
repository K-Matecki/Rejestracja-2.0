using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using Rejestracja.Models;
namespace Rejestracja.ViewModels
{
    class MainWindowViewModel  
    {
        public List<ItemMenu> ItemMenuList= new List<ItemMenu>();

        public MainWindowViewModel() 
        {
            var MenuPatients = new List<SubItem>();
            MenuPatients.Add(new SubItem("Dodaj pacjenta", 1));
            MenuPatients.Add(new SubItem("Usuń pacjenta", 2));
            MenuPatients.Add(new SubItem("Edytuj informacje o pacjencie", 3));
            MenuPatients.Add(new SubItem("Wyświetl informacje o pacjencie", 4));

            ItemMenuList.Add(new ItemMenu("Pacjent", MenuPatients, PackIconKind.UserHeart));

            var MenuDoctors = new List<SubItem>();
            MenuDoctors.Add(new SubItem("Dodaj lekarza", 5));
            MenuDoctors.Add(new SubItem("Usuń lekarza", 6));
            MenuDoctors.Add(new SubItem("Edytuj informacje o lekarzu", 7));
            MenuDoctors.Add(new SubItem("Wyświetl informacje o lekarzu", 8));
            ItemMenuList.Add(new ItemMenu("Lekarz", MenuDoctors, PackIconKind.Doctor));

            var MenuApointments = new List<SubItem>();
            MenuApointments.Add(new SubItem("Dodaj termin", 9));
            MenuApointments.Add(new SubItem("Usuń termin", 10));
            MenuApointments.Add(new SubItem("Edytuj termin", 11));
            MenuApointments.Add(new SubItem("Wyświetl wszystkie termin", 12));
            ItemMenuList.Add(new ItemMenu("Termin", MenuApointments, PackIconKind.UserClock));

        }
         
    }
}
