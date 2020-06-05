﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;

namespace Rejestracja
{
   public class Person :IModify
    {
        private string _name;
        private string _surname;
        private string _pesel;
        private Gender _sex;
        public enum Gender { K, M, Empty };
        private DateTime _birthday;
        private int _age;
        private TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        public string Name { get { return ti.ToTitleCase(_name); } }
        public string Surname { get { return ti.ToTitleCase(_surname); } }
        public string Pesel { get { return _pesel; } }
        public Gender Sex { get { return _sex; } }
        public DateTime BirthDay { get { return _birthday; } }
        public int Age { get { return _age; } }


        public  Person()
        {
            _name = string.Empty;
            _surname = string.Empty;
            _pesel = string.Empty;
            _sex = Gender.Empty;
        }


     
        public Person(string imie, string nazwisko, string pesel) : this()
        {

             if (SprawdzString(imie) == true && SprawdzString(nazwisko) == true)
             {
              _name = imie;
            _surname = nazwisko;
             }
             
            if (SprawdzPesel(pesel) == true)
            {
                _pesel = pesel;
                GetBirthDay(_pesel);
                _sex = pesel[9] % 2 == 0 ? Gender.K : Gender.M; 
                _age = DateTime.Today.Year - BirthDay.Year; 
            }
        }
    
        public virtual bool Edit()
        {
            throw new Exception("Metoda nie została zdefiniowana");
        }
        public virtual bool Remove()
        {
            throw new Exception("Metoda nie została zdefiniowana");
        }
        public virtual void UpdateAppointments()
        {
            throw new Exception("Metoda nie została zdefiniowana");
        }

        //lista termnów 
        //walidacja do poprawy 
        private bool SprawdzPesel(string Pesel)
        {
            if (Pesel.Length != 11) {
                MessageBox.Show("Pesel musi mieć długość 11 znaków");
                return false; 
            }
            foreach (char c in Pesel)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Pesel musi zawierać same cyfr");
                    return false;
                }
               
            }
            return true;
        }

      
        protected string WprowadzString(string Tekst)
        {
            string zmienna;
            do
            {
                Console.Write($"Wprowadz {Tekst}:");
                zmienna = Console.ReadLine();
            } while (string.IsNullOrEmpty(zmienna));

            return zmienna;
        }
        private bool SprawdzString(string Zmienna)
        {
            foreach (char c in Zmienna)
            {
                if (!char.IsLetter(c))
                    throw new Exception($"Musisz wprowadzic same litery");
            }
            return true;
        }
        //funkcja przypisująca wiek na podstawie podanego peselu 
        private void GetBirthDay(string pesel)
        {
            int Year = 0, Month = 0, Day = 0;
            string s_year = string.Empty;
            string s_day = string.Empty;
            switch (pesel[2])
            {
                case '0':
                case '1':
                    s_year = "19";
                    break;
                case '2':
                case '3':
                    s_year = "20";
                    break;
                case '4':
                case '5':
                    s_year = "21";
                    break;
                case '6':
                case '7':
                    s_year = "22";
                    break;
                case '8':
                case '9':
                    s_year = "18";
                    break;
                default:
                    throw new Exception("osoba już lub jeszcze nie żyje urodzona po za przedziałem 1800-2299");
            }
            s_year += pesel[0];
            s_year += pesel[1];
            Year = int.Parse(s_year);

            if (pesel[3] > 12 && pesel[3] < 0)
                throw new Exception("Miesiąc musi być z zakresu 1-12");

            if (pesel[3] > 2)
                Month = int.Parse(pesel[3].ToString());
            else
            {
                switch (pesel[3])
                {
                    case '0':
                        Month = 10;
                        break;
                    case '1':
                        if (pesel[2] % 2 == 0)
                            Month = 1;
                        else
                            Month = 11;
                        break;
                    case '2':
                        if (pesel[2] % 2 == 0)
                            Month = 2;
                        else
                            Month = 12;
                        break;
                }
            }
            s_day += pesel[4];
            s_day += pesel[5];
           
            Day = int.Parse(s_day);

            if (Day > 31 && Day < 0)
                throw new Exception("Dzien musi być z zakresu 1-31");

            if (Month % 2 != 0)
                if (Day == 31)
                    throw new Exception("Ten miesiąc ma mniej niż 31 dni");
            if (Month == 2)
                if (Day > 29)
                    throw new Exception($"Luty ma mniej niż 30 dni {Day}/{Month}/{Year}");

            _birthday = new DateTime(Year, Month, Day);

        }

     
    }
}