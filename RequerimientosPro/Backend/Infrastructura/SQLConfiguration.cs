using System;
using System.Data.SqlClient;
using System.Text;

namespace Backend.Infrastructura
{
    public sealed  class SQLConfiguration
    {

        private static SqlConnection _connection = new SqlConnection(GetDbString());
        public static string GetDbString()
        {
             StringBuilder bodyConection = new StringBuilder();

            string nombreServidor = "DESKTOP-IL6BT9M";
            string nombreBaseDeDatos = "test";

            var sqlUser = new { 
                NombreUsuario = "sa",
                Password = "7keylogger7"
            };

            var connection = new {
                dataSource = $"Data Source={nombreServidor};",
                catalog = $"Initial Catalog={nombreBaseDeDatos};",
                userId = $"User ID={sqlUser.NombreUsuario};Password={sqlUser.Password}"
            };

            bodyConection.Append(connection.dataSource);
            bodyConection.Append(connection.catalog);
            bodyConection.Append(connection.userId);


            return bodyConection.ToString();

        }

        public static void Open()
        {
             _connection.Open();
        }

        public static SqlConnection GetConnection() 
        {
            return _connection;
        }


        public static void Close()
        {
            _connection.Close();
        }

    }
}
