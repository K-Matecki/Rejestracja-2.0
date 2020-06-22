using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Rejestracja.Models
{
   public  class Doctor :Person
    {
        public int IdDoctor { get; }
       
        public List<Appointment> DoctorAppointment = new List<Appointment>();
        public Doctor():base()
        {
            IdDoctor = GetHashCode(); 
        }

        public Doctor(string name, string surname, string pesel) : base(name, surname, pesel)
        {
            Add();
            IdDoctor = DataBase.GetIndex("doctors");
        }
        public Doctor(int id, string name, string surname, string pesel) : base(name, surname, pesel)
        {
            IdDoctor = id;
        }
        public Doctor(string[] StringArryData) : base(StringArryData[1], StringArryData[2], StringArryData[3])
        {
            IdDoctor = int.Parse(StringArryData[0]);
        }
        //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie
        private void Add()
        {
            
            if (!DataBase.ModifyData($"INSERT INTO doctors(name, surname, pesel, age, sex) VALUES( '{Name}', '{Surname}', '{Pesel}', {Age}, '{Sex}')"))
                throw new Exception("Nieudane połączenie z baza {}");
            else
                MessageBox.Show("Pomyślnie dodano osobę");
        }
        //funkcja aktualizująca rekord w bazie danych 
        public override bool Edit(string name, string surname)
        {
            _name = name;
            _surname = surname;
            return DataBase.ModifyData($"UPDATE doctors SET name= '{Name}', surname ='{Surname}' where id_doctor={IdDoctor}");
        }
        public override bool Remove()
        {
            if (DataBase.ModifyData($"Delete from appointments where id_doctor = {IdDoctor}"))
                return DataBase.ModifyData($"Delete from doctors where id_doctor = {IdDoctor}");
            else
                return false;
        }
        public override void UpdateAppointments()
        {
            DoctorAppointment = DataBase.UpdateAppointmentList(IdDoctor, "doctors");
        }
        
    }
}
