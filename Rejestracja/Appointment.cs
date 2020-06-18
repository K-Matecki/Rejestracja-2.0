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
        public int IdAppointment { get;  }
        public DateTime AppointmentDate { get; private set; }
         
        public Appointment()
        {
            Doctor = null;
            Patient = null;
            AppointmentDate = new DateTime();
            IdAppointment = GetHashCode();
        }
        public Appointment(DateTime data, Person lekarz, Person pacjent) 
        {
            Doctor =  (Doctor)lekarz;
            Patient =  (Patient)pacjent;
            AppointmentDate = data;
            Add();
            IdAppointment = DataBase.GetIndex("appointments");

        }
        public Appointment(int id,DateTime data, Doctor lekarz, Patient pacjent) 
        {
            Doctor = (Doctor)lekarz;
            Patient = (Patient)pacjent;
            AppointmentDate = data;
            IdAppointment = id;
        }
       //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie 
        private void Add()
        {  
           if (!DataBase.ModifyData($"INSERT INTO Appointments(id_doctor,id_patient,date) VALUES({Doctor.IdDoctor},{Patient.IdPatient},'{AppointmentDate}')"))
                throw new Exception("Nieudane połączenie z baza ");
            else
                MessageBox.Show("Pomyślnie dodano termin");
        }

        public  bool Edit(DateTime date)
        {
            AppointmentDate = date;
             return DataBase.ModifyData($"UPDATE appointments SET date= '{AppointmentDate}' where id_appointment='{IdAppointment}'");
        }
        public  bool Remove()
        {   //dodaj usuwanie nieaktualnych terminów 
            return DataBase.ModifyData($"Delete from appointments where id_appointment = '{IdAppointment}'"); ;
        }
    }
}


/*
select id_appointment,concat(doctors.name, ' ', doctors.surname) as Doktor ,
concat(patients.name, ' ', patients.surname) as Pacjent ,date 
from appointments natural join patients natural join doctors
*/
