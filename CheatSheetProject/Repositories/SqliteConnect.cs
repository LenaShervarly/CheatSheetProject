using System;
using System.Data.Entity;
using System.Data.SQLite;

namespace CheatSheetProject.Repositories
{
    public class SqliteConnect
    {
        public SqliteConnect()
        {
        }

        public static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
         // Open the connection:
         try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
    }
}

