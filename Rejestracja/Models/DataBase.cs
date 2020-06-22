using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows;
namespace Rejestracja.Models
{
    class DataBase
    {
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "postgres";
        private static string Password = "123";
        private static string Port = "5432";
        private static string ConnString = String.Format($"Server={Host};Username={User};Database={DBname};Port={Port};Password={Password};SSLMode=Prefer");
        public static NpgsqlConnection Connection = new NpgsqlConnection(ConnString);
    
     
        public static List<string> GetData(string SQLCommand, string TableName)
        {
            List<string> DataItems = new List<string>();
            int ColumnNumber = GetColumnNumber(TableName);
            string AddString = "";
            try
            {
                
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
                DataReader.DisposeAsync();
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
                var Command = new NpgsqlCommand(SQLCommand, Connection);
                Command.ExecuteNonQuery();
                Command.Dispose();
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
            
          
            NpgsqlDataReader ColumnInfo = new NpgsqlCommand($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE table_catalog = '{DBname}' AND table_name='{TableName}'", Connection).ExecuteReader();
            ColumnInfo.Read();
            int.TryParse(ColumnInfo[0].ToString(), out ColumnCount);
            ColumnInfo.DisposeAsync();
            return ColumnCount;
        }

        static public int GetIndex(string TableName)
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

            NpgsqlDataReader IdInfo = new NpgsqlCommand($"SELECT Max({IdName}) FROM {TableName} limit 1", Connection).ExecuteReader();
            IdInfo.Read();
            int.TryParse(IdInfo[0].ToString(), out Id);
            IdInfo.DisposeAsync();
             return Id;
        }
        public static (List<string>, List<Person>) GetComboBoxListPerson(int MenuID)  
        {
            string[] Line;
            List<string> ComboBoxList = new List<string>();
            List<string> StringData = GetStringDataList(MenuID);
            List<Person> PersonList = new List<Person>();
            switch (MenuID) 
            {
                case 2:
                case 3:
                case 4:
                case 6:
                case 7:
                case 8:
                     if (PersonList.Count != 0)
                        PersonList.Clear();

                    foreach (var item in StringData)
                    {
                        Line = item.Split(',');
                        switch (MenuID)
                        {
                            case 2:
                            case 3:
                            case 4:
                                PersonList.Add(new Patient(int.Parse(Line[0]), Line[1], Line[2], Line[3]));
                                break;
                            case 6:
                            case 7:
                            case 8:
                                PersonList.Add(new Doctor(int.Parse(Line[0]), Line[1], Line[2], Line[3]));
                                break;
                        }

                    }
                    foreach (var item in PersonList)
                    {
                        ComboBoxList.Add($"{item.Name} {item.Surname}");
                    }
                    break;
               
            }
            return (ComboBoxList, PersonList);
        }
        public static (List<string>, List<Appointment>) GetComboBoxListAppointment(int MenuID)
        {
            List<string> ComboBoxList = new List<string>();
            List<string> StringData = GetStringDataList(10);
            List<Appointment> AppointmentList =new List<Appointment>();

            AppointmentList = GetAppointmentList(StringData);
            foreach (var item in AppointmentList)
            {
                ComboBoxList.Add($"{item.Doctor.Name} {item.Doctor.Surname}|{item.Patient.Name} {item.Patient.Surname}|{item.AppointmentDate.ToString()} ");
            }
            return (ComboBoxList, AppointmentList);
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

        public static List<Appointment> UpdateAppointmentList(int PersonID, string TableName)
        {
            List<Appointment> AppointmentList = new List<Appointment>();
            List<string> DataStringList = new List<string>();

            //rozdzielenie na pacjenta i lekarza 
            string IdName = "id_";
            switch (TableName)
            {
                case "doctors":
                    IdName += "doctor";
                    break;
                case "patients":
                    IdName += "patient";
                    break;
                 

            }
            DataStringList = GetData($"SELECT * FROM appointments where {IdName}= '{PersonID}' ", "appointments");
            if (DataStringList.Count == 0)
                MessageBox.Show("Ten osoba nie ma terminów");
            else
                AppointmentList= GetAppointmentList(DataStringList);
            
            return AppointmentList;

        }


    

        private static List<Appointment> GetAppointmentList(List<string>  DataStringList)
        {
            List<Appointment> AppointmentList = new List<Appointment>();
            List<string> StringDataDoctor, StringDataPatient;
            string[] LineDoctor, LinePatient;
            string[] LineAppointment;
            // nie działa dla person 
            foreach (var item in DataStringList)
            {
                LineAppointment = item.Split(',');
                StringDataDoctor = GetData($"select * from doctors where id_doctor = {LineAppointment[1]}", "doctors");
                StringDataPatient = GetData($"select * from patients where id_patient = {LineAppointment[2]}", "patients");
                LineDoctor = StringDataDoctor[0].Split(',');
                LinePatient = StringDataPatient[0].Split(',');
                AppointmentList.Add(new Appointment(int.Parse(LineAppointment[0]), Convert.ToDateTime(LineAppointment[3]), new Doctor(LineDoctor), new Patient(LinePatient)));
            }
            return AppointmentList;
        }

    }
}


