using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace ToDoList.Core
{
    internal static class DBConnection
    {
        private static SQLiteConnection _conn;
        public static SQLiteConnection GetConnection()
        {
            _conn = new SQLiteConnection("Data Source=..\\..\\ToDoList_db\\database.db");
            try
            {
                if(_conn.State != ConnectionState.Open) _conn.Open();
                MessageBox.Show("Connection is success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                if (_conn.State == ConnectionState.Open) _conn.Close();
                _conn = null;
            }


            return _conn;
        }

        //public static DataTable GetDataTable(string SQLText)
        //{
        //    SqlConnection con = GetConnection();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter adapter = new SqlDataAdapter(SQLText, con);
        //    adapter.Fill(dt);

        //    return dt;
        //}
    }
}
