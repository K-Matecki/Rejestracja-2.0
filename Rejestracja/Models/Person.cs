using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;

namespace Rejestracja.Models
{
   public abstract class Person  
    {
        protected string _name;
        protected string _surname;

        public enum Gender { K, M, Empty };
        private DateTime _birthday;
         private TextInfo _textinfo = CultureInfo.CurrentCulture.TextInfo;
        public string Name { get { return _textinfo.ToTitleCase(_name); } }
        public string Surname { get { return _textinfo.ToTitleCase(_surname); } }
        public string Pesel { get;}
        public Gender Sex { get;}
        public int Age { get { return DateTime.Today.Year - _birthday.Year; } }


        protected Person()
        {
            _name = string.Empty;
            _surname = string.Empty;
            Pesel = string.Empty;
            Sex = Gender.Empty;
             
        }



        protected Person(string name, string surname, string pesel) : this()
        {   
            _name = name;
            _surname = surname;
            Pesel = pesel;
            _birthday = GetBirthDay(pesel);
            Sex = pesel[9] % 2 == 0 ? Gender.K : Gender.M;
            
        }


        public abstract bool Edit(string name, string surname);
        
        public abstract bool Remove();
     
        public abstract void UpdateAppointments();


        private  DateTime GetBirthDay(string pesel)
        {
            
            string date;
            switch (pesel[2])
            {
                case '0':
                case '1':
                    date = "19";
                    break;
                case '2':
                case '3':
                    date = "20";
                    break;
                case '4':
                case '5':
                    date = "21";
                    break;
                case '6':
                case '7':
                    date = "22";
                    break;
                case '8':
                case '9':
                    date = "18";
                    break;
                default:
                    date = "XX";
                    break;
            }
            date += $"{pesel[0]}{pesel[1]}-";


            if (int.Parse(pesel[3].ToString()) >= 3)
                date += $"0{pesel[3]}";
            else
            {
                switch (pesel[3])
                {
                    case '0':
                        date += "10";
                        break;
                    case '1':
                        if (pesel[2] % 2 == 0)
                            date += $"0{pesel[3]}";
                        else
                            date += "11";
                        break;
                    case '2':
                        if (pesel[2] % 2 == 0)
                            date += $"0{pesel[3]}";
                        else
                            date += "12";
                        break;
                }
            }
            date += $"-{pesel[4]}{pesel[5]}";

            if (!DateTime.TryParse(date, out _birthday))
                throw new ArgumentException("Nieprawidołowa data urodzenia");
            
            return _birthday;
        }
    }
}
