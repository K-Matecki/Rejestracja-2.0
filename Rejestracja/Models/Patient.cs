using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Rejestracja.Models
{
    public class Patient : Person
    {
        public int IdPatient { get;}
         
        public List<Appointment> PatientAppointments = new List<Appointment>();
        public Patient() : base()
        {
            IdPatient = GetHashCode();
        }
        public Patient(string name, string surname, string pesel) : base(name, surname, pesel)
        {
            Add();
            IdPatient = DataBase.GetIndex("patients");
        }
        public Patient(int id ,string name, string surname, string pesel) : base(name, surname, pesel)
        {
            IdPatient = id;
        }
        public Patient(string[] StringArryData) : base( StringArryData[1], StringArryData[2], StringArryData[3])
        {
            IdPatient = int.Parse(StringArryData[0]);
        }
        //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie
        private void Add()
        {
           
           if(!DataBase.ModifyData($"INSERT INTO patients(name, surname, pesel, age, sex) VALUES('{Name}', '{Surname}', '{Pesel}', {Age}, '{Sex}')"))
                throw new Exception("Nieudane połączenie z baza {}");
           
        }
        public override bool Edit(string name, string surname)
        {
            _name = name;
            _surname = surname;
            return DataBase.ModifyData($"UPDATE patients SET name= '{Name}', surname ='{Surname}' where id_patient={IdPatient}");
            
        }
        public override bool Remove()
        {
            if(DataBase.ModifyData($"Delete from appointments where id_patient = {IdPatient}"))
            return DataBase.ModifyData($"Delete from patients where id_patient = {IdPatient}");
            else
                return false;
        }
        public override void  UpdateAppointments()
        {
            PatientAppointments = DataBase.UpdateAppointmentList(IdPatient, "patients");
        }
    }
}
 