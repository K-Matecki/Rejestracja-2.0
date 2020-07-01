using GalaSoft.MvvmLight.Messaging;
using Rejestracja.Models;
using System.Windows.Input;

namespace Rejestracja.ViewModels
{
    class AddPersonViewModel : BasePersonViewModel
    {
        private Person NewPerson;
        public ICommand AddPersonCommand { get; }
        private bool SelectedPerson;

        public AddPersonViewModel(int MenuID) : base(MenuID)
        {
            SelectedPerson = Menu == 1 ? true : false;
            AddPersonCommand = new RelayCommand(Add, CanAddPerson);

        }
        private bool CanAddPerson()
        {
            return IsValidateEdit;
        }
        private void Add()
        {
            if (SelectedPerson)
                NewPerson = new Patient(Name, Surname, Pesel);
            else
                NewPerson = new Doctor(Name, Surname, Pesel);
            Messenger.Default.Send<MyMessage>(new MyMessage { MessageText = $"Pomyślnie dodano {NewPerson.Name} {NewPerson.Surname}" });

        }
    }
}
