﻿using System;
using System.Data.SqlClient;

namespace Backend.Infrastructura
{
    public class SQLConfiguration: IDisposable
    {
        private static string _stringConnection = "Data Source=DESKTOP-IL6BT9M;Initial Catalog=AttRequerimientoDb;User ID=sa;Password=7keylogger7";

        private SqlConnection _connection;
        public SQLConfiguration()
        {          
            _connection = new SqlConnection(_stringConnection);
        }

        public static string GetStringConnection() {
            return _stringConnection;
        }

        public SqlConnection GetConnection() { return _connection; }

        public void OpenConnection() {
             _connection.Open();
        }


        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
