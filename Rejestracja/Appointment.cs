using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejestracja
{
    public class Appointment    
    {
        public DateTime Data;
        public Person Lekarz;
        public Person Pacjent;
        public int IdAppointment { get { return _idAppointment; } }
        public int _idAppointment;
        public Appointment()
        {
            Lekarz = null;
            Pacjent = null;
            Data = new DateTime();
            _idAppointment = GetHashCode();
        }
        public Appointment(DateTime data, Person lekarz, Person pacjent) 
        {
            Lekarz = lekarz;
            Pacjent = pacjent;
            Data = data;
            Add();
           
        }
        public Appointment(int id,DateTime data, Person lekarz, Person pacjent) : this(data, lekarz, pacjent)
        {
            _idAppointment = id;
        }
       //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie 
        private bool Add()
        { //
            _idAppointment = -1;//z bazy 
            return false;
        }

        public  bool Edit()
        {
            return false;
        }
        public  bool Remove()
        {
            return false;
        }
    }
}
