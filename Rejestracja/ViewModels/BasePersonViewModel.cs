using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Rejestracja.Models;
namespace Rejestracja.ViewModels
{
    public abstract class BasePersonViewModel : ViewModelBase, IDataErrorInfo
    {
        public string Error { get { return null; } }

        protected int Menu;
        public List<string> _comboBoxPerson;
        private string _name;
        private string _surname;
        private string _pesel;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged(); }
        }

        public string Pesel
        {
            get { return _pesel; }
            set { _pesel = value; OnPropertyChanged(); }
        }

        private bool[] ValidateResult = new bool[3];
        protected bool IsValidateEdit { get { return ValidateResult[0] && ValidateResult[1]; } }
        protected bool IsValidateAdd { get { return ValidateResult[0] && ValidateResult[1] && ValidateResult[2]; } }

        public BasePersonViewModel(int MenuId)
        {
            Name = string.Empty;
            Surname = string.Empty;
            Pesel = string.Empty;
            Menu= MenuId;
        }

        public string this[string PropertyName]
        {
            get
            {
                string result = null;

                switch (PropertyName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                            result = "Uzupełnij pole Imie";
                        else if (CheckString(Name) == false)
                            result = "Imię zawiera niedozwolone znaki.";
                        else if (Name.Length < 3 || Name.Length > 51)
                            result = "Imię musi mieć długość od 3 do 51 znaków.";

                        ValidateResult[0] = result == null ? true : false;

                        break;

                    case "Surname":
                        if (string.IsNullOrEmpty(Surname))
                            result = "Uzupełnij pole Nazwisko";
                        else if (CheckString(Surname) == false)
                            result = "Nazwisko zawiera niedozwolone znaki.";
                        else if (Surname.Length < 3 || Surname.Length > 51)
                            result = "Nazwisko musi mieć długość od 3 do 51 znaków.";
                        ValidateResult[1] = result == null ? true : false;

                        break;

                    case "Pesel":
                        if (string.IsNullOrEmpty(Pesel))
                            result = "Uzupełnij pole Pesel";
                        else if (Pesel.Length != 11)
                            result = "Pesel musi mieć długość 11 znaków.";
                        else if (CheckPesel(Pesel) == false)
                            result = "Nieprawidłowy Pesel";
                        else if(CheckPeselUnique(Pesel))
                            result = "Osoba z tym peselem istnieje w bazie";
                        
                        ValidateResult[2] = result == null ? true : false;
                        break;
                }
                return result;
            }

        }

        private bool CheckString(string input)
        { 
            return Regex.IsMatch(input, @"^[a-ząćęłńóśźżA-ZĄĆĘŁŃÓŚŹŻ]+$");
        }

        private bool CheckPesel(string pesel)
        {

            var Match = Regex.IsMatch(pesel, @"^[\d-]+$");

            if (!Match)
                return false;

            int ControlSum = 0;
            int[] ControlNumber = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };

            for (int i = 0; i < pesel.Length; i++)
                ControlSum += ControlNumber[i] * (int)pesel[i];
            return ControlSum % 10 == 0 ? true : false;
        }

        private bool CheckPeselUnique(string pesel)
        {
            var Pesels = DataBase.GetPeselList(Menu);
            return Pesels.Contains(pesel);
             
        }
    }
}
