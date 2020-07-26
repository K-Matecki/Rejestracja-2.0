using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Rejestracja.Models
{
    public class Appointment    
    { 
        private int IdDoctor;
        private int IdPatient;
        public int IdAppointment { get;}
        public DateTime AppointmentDate { get; private set; }
        public string PatientFullName { get; }
        public string DoctorFullName { get; }

        public Appointment()
        {
            IdPatient= GetHashCode();
            IdDoctor = GetHashCode();
            AppointmentDate = new DateTime();
            IdAppointment = GetHashCode();
        }
        public Appointment(DateTime date, Person doctor, Person patient) 
        {
            IdDoctor =  ((Doctor)doctor).IdDoctor;
            IdPatient =  ((Patient)patient).IdPatient;
            AppointmentDate = date;
            Add();
            IdAppointment = DataBase.GetIndex("appointments");
            DoctorFullName = doctor.Name + " " + doctor.Surname;
            PatientFullName = patient.Name + " " + patient.Surname;
        }
        public Appointment(int id,DateTime date, Doctor doctor, Patient patient) 
        {
            IdDoctor = ((Doctor)doctor).IdDoctor;
            IdPatient = ((Patient)patient).IdPatient;
            AppointmentDate = date;
            IdAppointment = id;
            DoctorFullName = $"{doctor.Name}  {doctor.Surname}";
            PatientFullName =$"{patient.Name} {patient.Surname}";
        }
       //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie 
        private void Add()
        {  
           if (!DataBase.ModifyData($"INSERT INTO Appointments(id_doctor,id_patient,date) VALUES({IdDoctor},{IdPatient},'{AppointmentDate}')"))
                throw new Exception("Nieudane połączenie z baza");
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
