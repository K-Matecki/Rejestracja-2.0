using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Rejestracja
{
    class Patient : Person
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
        }
        public Patient(int id ,string imie, string nazwisko, string pesel) : base(imie, nazwisko, pesel)
        {
            _idPatient = id;
        }
        //funkcja dodająca obiekt do bazy ustawia id obiektu zgodne z rekordem w bazie
        private void Add()
        {
            _idPatient = DataBase.GetNextIndex("patients");
           if(!DataBase.ModifyData($"INSERT INTO patients VALUES({_idPatient}, '{Name}', '{Surname}', '{Pesel}', {Age}, '{Sex}')"))
                throw new Exception("Nieudane połączenie z baza {}");
           else
                MessageBox.Show("Pomyślnie dodano osobę");
        }
        public override bool EditInDatabase(string name, string surname)
        {
            Edit(name,surname);
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
            List<string> test = new List<string>();
            test = DataBase.GetData($"SELECT * FROM appontments where id_patient='{IdPatient}' ", "patients");
            if (test == null)
                MessageBox.Show("Ten pacjent nie ma terminów");
        }
    }
}
