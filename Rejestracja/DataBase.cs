using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows;
namespace Rejestracja
{
    class DataBase
    {
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "postgres";
        private static string Password = "123";
        private static string Port = "5432";
        private static string ConnString = String.Format($"Server={Host};Username={User};Database={DBname};Port={Port};Password={Password};SSLMode=Prefer");
        private static NpgsqlConnection Connection = new NpgsqlConnection(ConnString);
        public static List<Person> PersonList { get { return _personList; } }
        private static List<Person> _personList = new List<Person>();
        public static List<Appointment> AppointmentList { get { return _appointmentList; } }
        private static List<Appointment> _appointmentList = new List<Appointment>();
        //dodać sprawdzenie połączenia 
        public static List<string> GetData(string SQLCommand, string TableName)
        {
            List<string> DataItems = new List<string>();
            int ColumnNumber = GetColumnNumber(TableName);
            string AddString = "";
            try
            {
                Connection.Open();
                var Command = new NpgsqlCommand(SQLCommand, Connection);
                NpgsqlDataReader DataReader = Command.ExecuteReader();

                while (DataReader.Read())
                {
                    for (int i = 0; i < ColumnNumber; i++)
                    {
                        AddString += DataReader[i].ToString();
                        AddString += ",";
                    }
                    AddString += ";";
                    DataItems.Add(AddString);
                    AddString = "";
                }
                Connection.Close();
                return DataItems;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public static bool ModifyData(string SQLCommand)
        {
            try
            {
                Connection.Open();
                var Command = new NpgsqlCommand(SQLCommand, Connection);
                Command.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        private static int GetColumnNumber(string TableName)
        {
            int ColumnCount;
            var Connection = new NpgsqlConnection(ConnString);
            Connection.Open();
            NpgsqlDataReader ColumnInfo = new NpgsqlCommand($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE table_catalog = '{DBname}' AND table_name='{TableName}'", Connection).ExecuteReader();
            ColumnInfo.Read();
            int.TryParse(ColumnInfo[0].ToString(), out ColumnCount);
            Connection.Close();
            return ColumnCount;
        }

        static public int GetNextIndex(string TableName)
        {
            int Id;
            string IdName = "id_";
            switch (TableName)
            {
                case "doctors":
                    IdName += "doctor";
                    break;
                case "patients":
                    IdName += "patient";
                    break;
                case "appointments":
                    IdName += "appointment";
                    break;
                default:
                    IdName = null;
                    break;
            }

            Connection.Open();
            NpgsqlDataReader IdInfo = new NpgsqlCommand($"SELECT Max({IdName}) FROM {TableName} limit 1", Connection).ExecuteReader();
            IdInfo.Read();
            int.TryParse(IdInfo[0].ToString(), out Id);
            Console.WriteLine(Id);
            Connection.Close();
            if (Id == 0)
                return 1;
            return Id + 1;
        }
        public static List<string> GetComboBoxList(int MenuID)
        {
            string[] Line;
            List<string> ComboBoxList = new List<string>();
            List<string> StringData = GetStringDataList(MenuID);
            
            switch (MenuID) 
            {
                case 2:
                case 3:
                case 4:
                case 6:
                case 7:
                case 8:
                     if (_personList.Count != 0)
                     _personList.Clear();

                    foreach (var item in StringData)
                    {
                        Line = item.Split(',');
                        switch (MenuID)
                        {
                            case 2:
                            case 3:
                            case 4:
                                _personList.Add(new Patient(int.Parse(Line[0]), Line[1], Line[2], Line[3]));
                                break;
                            case 6:
                            case 7:
                            case 8:
                                _personList.Add(new Doctor(int.Parse(Line[0]), Line[1], Line[2], Line[3]));
                                break;
                        }

                    }

                    foreach (var item in _personList)
                    {
                        ComboBoxList.Add($"{item.Name} {item.Surname}");
                    }
                    break;
                case 10:
                case 11:
                case 12:
                    if (_appointmentList.Count != 0)
                        _appointmentList.Clear();
                    GetAppointmentList(StringData);
                    foreach (var item in AppointmentList)
                    {
                        ComboBoxList.Add($"{item.Doctor.Name} {item.Doctor.Surname}|{item.Patient.Name} {item.Patient.Surname}|{item.AppointmentDate.ToString()} ");
                    }
                    break;
            }
            return ComboBoxList;
        }

        public static List<string> GetStringDataList(int MenuID)
        {

            List<string> StringData = new List<string>();

            switch (MenuID)
            {
                case 2:
                case 3:
                case 4:
                    StringData = GetData("select * from patients", "patients");
                    break;
                case 6:
                case 7:
                case 8:
                    StringData = GetData("select * from doctors", "doctors");
                    break;
                case 10:
                case 11:
                case 12:
                    StringData = GetData("select * from appointments", "appointments");
                    break;
                default:
                    StringData.Add("");
                    break;
            }
            return StringData;
        }
        public static List<Appointment> UpdateAppointmentList(int PersonID)
        {
            List<Appointment> AppointmentList = new List<Appointment>();
            List<string> DataStringList = new List<string>();
            DataStringList = GetData($"SELECT * FROM appointments where id_patient='{PersonID}' ", "appointments");
          
            
            if (DataStringList == null)
                MessageBox.Show("Ten osoba nie ma terminów");
            else
            GetAppointmentList(DataStringList);
            
            return AppointmentList;

        }

        private static void GetAppointmentList(List<string>  DataStringList)
        {
            List<string> StringDataDoctor, StringDataPatient;
            string[] LineDoctor, LinePatient;
            string[] LineAppointment;

            foreach (var item in DataStringList)
            {
                LineAppointment = item.Split(',');
                StringDataDoctor = DataBase.GetData($"select * from doctors where id_doctor = {LineAppointment[1]}", "doctors");
                StringDataPatient = DataBase.GetData($"select * from patients where id_patient = {LineAppointment[2]}", "patients");
                LineDoctor = StringDataDoctor[0].Split(',');
                LinePatient = StringDataPatient[0].Split(',');
                _appointmentList.Add(new Appointment(int.Parse(LineAppointment[0]), Convert.ToDateTime(LineAppointment[3]), new Doctor(LineDoctor), new Patient(LinePatient)));
            }
        }

    }
}


