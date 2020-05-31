﻿using System;
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

        public static List<string> GetData(string SQLCommand)
        {
            try
            {
                var Connection = new NpgsqlConnection(ConnString);
                Console.Out.WriteLine("Opening connection");
                Connection.Open();
                var Command = new NpgsqlCommand(SQLCommand, Connection);
                NpgsqlDataReader DataReader = Command.ExecuteReader();
               // NpgsqlDataReader ColumnInfo = new NpgsqlCommand($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE table_catalog = '{DBname}' AND table_name='doctors'", Connection).ExecuteReader();
                int ColumnCount = 6;
                string Add="";
                
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
                var Connection = new NpgsqlConnection(ConnString);
                Console.Out.WriteLine("Opening connection");
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

       
    }
}

