using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Rejestracja.Models;

namespace Rejestracja.ViewModels
{
    class AddPersonViewModel : BasePersonViewModel
    {
        private Person NewPerson;
        public ICommand AddPersonCommand { get; }
        private bool SelectedPerson;
        
        public AddPersonViewModel(int MenuID):base()
        { 
            SelectedPerson = MenuID == 1 ? true : false;
            AddPersonCommand = new RelayCommand(Add, CanAddPerson);
           
        }
        private bool CanAddPerson()
        {
            return IsValidateAdd;  
        }
        private void Add() 
        {
            if (SelectedPerson)
                NewPerson = new Patient(Name, Surname, Pesel);
            else
                NewPerson = new Doctor(Name, Surname, Pesel);

           // MessageBox.Show($"Pomyślnie dodano {NewPerson.Name} {NewPerson.Surname}");
        }
    }
}
