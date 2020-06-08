using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejestracja
{
   public  class Doctor :Person
    {
        public int IdDoctor { get { return _idDoctor; } }
        private int _idDoctor;
        public List<Appointment> DoctorAppointment = new List<Appointment>();
        public Doctor():base()
        {
            _idDoctor = GetHashCode(); 
        }

        public Doctor(string imie, string nazwisko, string pesel) : base(imie, nazwisko, pesel)
        {
            Add();
        }
        public Doctor(int id, string imie, string nazwisko, string pesel) : base(imie, nazwisko, pesel)
        {
            _idDoctor = id;
        }
        //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie
        private bool Add()
        {
            _idDoctor = GetHashCode();//z bazy 
            return false;
        }
        public override bool EditInDatabase(string name, string surname)
        {
            return false;
        }
        public override bool Remove()
        {
            return false;
        }
        public override void UpdateAppointments()
        {
            
        }
        
    }
}
