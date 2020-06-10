using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public Doctor(string[] Line) : base(Line[1], Line[2], Line[3])
        {
            _idDoctor = int.Parse(Line[0]);
        }
        //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie
        private void Add()
        {
            _idDoctor = DataBase.GetNextIndex("doctors");
            if (!DataBase.ModifyData($"INSERT INTO doctors VALUES({_idDoctor}, '{Name}', '{Surname}', '{Pesel}', {Age}, '{Sex}')"))
                throw new Exception("Nieudane połączenie z baza {}");
            else
                MessageBox.Show("Pomyślnie dodano osobę");
        }
        public override bool EditInDatabase(string name, string surname)
        {
            Edit(name, surname);
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
            DoctorAppointment = DataBase.UpdateAppointmentList(IdDoctor);
        }
        
    }
}
