using System;
using System.Data.SQLite;

namespace CheatSheetProject.Repositories
{
    public class SQLTableManagement
    {

        private static SQLiteConnection conn;
        public SQLTableManagement()
        {
        
        }

        public static void CreateTable(string Createsql)
        {
            SQLiteCommand sqlite_cmd = GetSQLiteConnection().CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertData(string tableName, string columnNames, string values)
        {
            SQLiteCommand sqlite_cmd = GetSQLiteConnection().CreateCommand();
            sqlite_cmd.CommandText = $"INSERT INTO {tableName} ({columnNames}) VALUES({values}); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static SQLiteDataReader ReadData(string tableName)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = GetSQLiteConnection().CreateCommand();
            sqlite_cmd.CommandText = $"SELECT * FROM {tableName}";

            return sqlite_cmd.ExecuteReader();
            //GetSQLiteConnection().Close();
        }

        private static SQLiteConnection GetSQLiteConnection()
        {
            if(conn == null)
            {
                conn = SqliteConnect.CreateConnection();
            }
            return conn;
        }
    }
}

