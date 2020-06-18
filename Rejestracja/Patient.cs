using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Rejestracja
{
    public class Patient : Person
    {
        public int IdPatient { get { return _idPatient; } }
        private int _idPatient;
        public List<Appointment> PatientAppointments = new List<Appointment>();
        public Patient() : base()
        {
            _idPatient = GetHashCode();
        }
        public Patient(string imie, string nazwisko, string pesel) : base(imie, nazwisko, pesel)
        {
            Add();
            _idPatient = DataBase.GetIndex("patients");
        }
        public Patient(int id ,string imie, string nazwisko, string pesel) : base(imie, nazwisko, pesel)
        {
            _idPatient = id;
        }
        public Patient(string[] Line) : base( Line[1], Line[2], Line[3])
        {
            _idPatient = int.Parse(Line[0]);
        }
        //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie
        private void Add()
        {
           
           if(!DataBase.ModifyData($"INSERT INTO patients(name, surname, pesel, age, sex) VALUES('{Name}', '{Surname}', '{Pesel}', {Age}, '{Sex}')"))
                throw new Exception("Nieudane połączenie z baza {}");
           else
                MessageBox.Show("Pomyślnie dodano osobę");
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
 