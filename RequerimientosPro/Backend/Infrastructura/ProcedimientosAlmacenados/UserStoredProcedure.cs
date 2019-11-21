using Backend.Infrastructura.ProcedimientosAlmacenados.Command;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructura.ProcedimientosAlmacenados
{
    public class UserStoredProcedure : IStoredProcedureWrititer<Usuarios>

    {
        public Usuarios Find(Usuarios usuario)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
         

            using (SqlCommand command = new SqlCommand("usp_ObtenerUsuarios",SQLConfiguration.GetConnection()))
            {

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add
                (
                    new Usuarios()
                    {
                        idUsuario = (int)reader["idUsuario"],
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        Estado = bool.Parse(reader["Estado"].ToString())
                    }
                );
                }

            }
            return usuarios.FirstOrDefault(u => u.NombreUsuario == usuario.NombreUsuario);
        }

        public DataTable ExecuteStoredProcedure(int id)
        {
         
            CommandSender cmdSender = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerProyectosEnEquipoDeProgramador")
                .WithParameter<int>("idUsuario", id)
                .Build();

            return GetDataByStoredProcedure(cmdSender);
        }


        public DataTable GetDataByStoredProcedure(CommandSender cmdSnd)
        {
            cmdSnd.GetResult().ExecuteReader();
            SqlDataAdapter sda = new SqlDataAdapter(cmdSnd.GetResult());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmdSnd.GetResult().Dispose();
            SQLConfiguration.Close();
            return dt;
        }

        public Usuarios ObtenerEntidadPorId(int idUsuario)
        {
            CommandSender cmdsender = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerCredencialUsuario")
                .WithParameter<int>("idUsuario",idUsuario)
                .Build();

            List<Usuarios> us = GetAnyDataByCommand<Usuarios>(cmdsender);
            return us.LastOrDefault(u => u.idUsuario == idUsuario) ;
        }

        public List<T> GetAnyDataByCommand<T>(CommandSender cmdSender)
        {
            DataTable table = GetDataByStoredProcedure(cmdSender);
            return ConvertToList<T>(table);
        }

        public List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }

        public List<Usuarios> CallStoredProcedure(Usuarios usuario)
        {
         
            using (SqlCommand command = new SqlCommand("usp_ValidarUsuario",
                SQLConfiguration.GetConnection()))
            {
                command.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                command.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = usuario.Password;
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                bool isOk = false;
                while (reader.Read())
                {
                    isOk = bool.Parse(reader["isOk"].ToString());
                 
                }
                if(isOk == false)
                {
                    return null;
                }

                SQLConfiguration.Close();
                
                List<Usuarios> usuarios = new List<Usuarios>();
                usuarios.Add(Find(usuario));
                return  usuarios;

            }
       
        }
    }
}
