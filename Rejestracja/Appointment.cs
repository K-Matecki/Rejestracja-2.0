using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Rejestracja
{
    public class Appointment    
    {
        
        public Doctor Doctor;
        public Patient Patient;
        public int IdAppointment { get { return _idAppointment; } }
        public DateTime AppointmentDate { get { return _appointmentDate; } }
        private int _idAppointment;
        private DateTime _appointmentDate;
        public Appointment()
        {
            Doctor = null;
            Patient = null;
            _appointmentDate = new DateTime();
            _idAppointment = GetHashCode();
        }
        public Appointment(DateTime data, Person lekarz, Person pacjent) 
        {
            Doctor =  (Doctor)lekarz;
            Patient =  (Patient)pacjent;
            _appointmentDate = data;
            Add();
           
        }
        public Appointment(int id,DateTime data, Doctor lekarz, Patient pacjent) 
        {
            Doctor = (Doctor)lekarz;
            Patient = (Patient)pacjent;
            _appointmentDate = data;
            _idAppointment = id;
        }
       //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie 
        private void Add()
        { //
            _idAppointment=DataBase.GetNextIndex("appointments");
           if (!DataBase.ModifyData($"INSERT INTO Appointments VALUES({IdAppointment},{Doctor.IdDoctor},{Patient.IdPatient},'{AppointmentDate}')"))
                throw new Exception("Nieudane połączenie z baza ");
            else
                MessageBox.Show("Pomyślnie dodano termin");
        }

        public  bool Edit(DateTime date)
        {
            _appointmentDate = date;
             return DataBase.ModifyData($"UPDATE appointments SET date= '{AppointmentDate}' where id_appointment='{IdAppointment}'");
        }
        public  bool Remove()
        {
            return DataBase.ModifyData($"Delete from appointments where id_appointment = '{IdAppointment}'"); ;
        }
    }
}


/*
select id_appointment,concat(doctors.name, ' ', doctors.surname) as Doktor ,
concat(patients.name, ' ', patients.surname) as Pacjent ,date 
from appointments natural join patients natural join doctors
*/
