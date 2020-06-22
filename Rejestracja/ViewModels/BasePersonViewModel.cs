using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejestracja.ViewModels
{
    public abstract class BasePersonViewModel : ViewModelBase
    {
        private string _name;
        private string _surname;
        private string _pesel;

        public string Name {
            get { return _name; }
            set { _name = value; OnPropertyChanged();}
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
        protected bool IsValidate;

        public BasePersonViewModel()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Pesel = string.Empty;
        }
    }
}
