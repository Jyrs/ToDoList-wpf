using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Core
{
    internal class SQLiteUserRepository 
        //: IRepository<User>
    {
        private SQLiteConnection _connection;

        public SQLiteUserRepository()
        {
            this._connection = DBConnection.GetConnection();
        }

        public void GetList()
        {

        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Create(User entity)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = _connection.CreateCommand();

            //sqlite_cmd.CommandText = $"INSERT INTO Users(Login_User, Password_User, Permit) VALUES('{entity.}', '{TextBox_TaskDescription.Text}', '{null}');";

            sqlite_cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User GetID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
