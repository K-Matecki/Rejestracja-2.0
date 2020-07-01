using GalaSoft.MvvmLight.Messaging;
using Rejestracja.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace Rejestracja.ViewModels
{
    class EditPersonViewModel : BasePersonViewModel
    {
        public int Index { get; set; }
        
        private List<Person> PersonList = new List<Person>();
        public ICommand EditPersonCommand { get; }
        public ICommand SelectionChangedCommand { get; }
        public EditPersonViewModel(int MenuID) : base(MenuID)
        {
             
            Update();
            EditPersonCommand = new RelayCommand(Edit, CanEditPerson);
            SelectionChangedCommand = new RelayCommand(Change);
            Index = -1;
        }
        public List<string> ComboBoxPerson
        {
            get
            {
                return _comboBoxPerson;
            }
            protected set
            {
                _comboBoxPerson = value;
                OnPropertyChanged();
            }
        }

        private void Edit()
        {
            string TextMessage = "";
            if (PersonList[Index].Edit(Name, Surname))
                TextMessage = "Pomyślna Edycja";
            else
                TextMessage = "Nieudana edycja";
            Messenger.Default.Send<MyMessage>(new MyMessage { MessageText = TextMessage });
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
        private void Change()
        {
            Name = PersonList[Index].Name;
            Surname = PersonList[Index].Surname;
        }
    }
}


