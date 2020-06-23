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
    class EditPersonViewModel : BasePersonViewModel
    {
        public int Index { get; set; }
        private int Menu;
        private List<Person> PersonList = new List<Person>();
        public List<string> _comboBoxPerson;
        public List<string> ComboBoxPerson
        {
            get
            {
                return _comboBoxPerson;
            }
            private set
            {
                _comboBoxPerson = value;
                OnPropertyChanged();
            }
        }
        public ICommand EditPersonCommand { get; }
        public ICommand SelectionChangedCommand { get; }
        public EditPersonViewModel(int MenuID):base()
        {
            Menu = MenuID;
            Update();
            EditPersonCommand = new RelayCommand(Edit, CanEditPerson);
            SelectionChangedCommand = new RelayCommand(Change);
            Index = -1;
        }

        private void Edit()
        {
            
            if (PersonList[Index].Edit(Name, Surname))
                MessageBox.Show("Pomyślna Edycja");
            else
                MessageBox.Show("Nieudana edycja");
            Update();
        }

        private bool CanEditPerson()
        {
            return Index > -1 && Index <= PersonList.Count && IsValidateEdit;
        }

        private void Update()
        {
            var ValuesPerson = DataBase.GetComboBoxListPerson(Menu);
            ComboBoxPerson = ValuesPerson.Item1;
            PersonList = ValuesPerson.Item2;
        }
        private void Change() {
            Name =  PersonList[Index].Name;
            Surname =  PersonList[Index].Surname;
        }
    }
}


