using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
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
        private static List<string> DataItems = new List<string>();
        private static NpgsqlConnection Connection = new NpgsqlConnection(ConnString);

        public static List<string> GetData(string SQLCommand, string TableName)
        {
            try
            {
                int ColumnCount = GetColumnNumber(TableName);
                Connection.Open();
                var Command = new NpgsqlCommand(SQLCommand, Connection);
                NpgsqlDataReader DataReader = Command.ExecuteReader();

                Console.WriteLine(ColumnCount);
                string Add = "";

                while (DataReader.Read())
                {
                    for (int i = 0; i < ColumnCount; i++)
                    {
                        Add += DataReader[i].ToString();
                        Add += ",";
                    }
                    Add += ";";
                    DataItems.Add(Add);
                    Add = "";
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
                Console.WriteLine(e.Message);
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
    }
}


