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

    public class UserStoredProcedure : IStoredProcWritter<Usuarios>
    {
        SqlStoredProcedureServiceManager _converter;

        public UserStoredProcedure()
        {
            _converter = new SqlStoredProcedureServiceManager();
        }
        public Usuarios Find(Usuarios usuario)
        {
            CommandSender cmdsender = new CommandSender.Builder()
              .SetProcedureName("usp_ObtenerUsuarios")
              .Build();
            List<Usuarios> usuarios = _converter.GetAnyDataByCommand<Usuarios>(cmdsender);

            SQLConfiguration.Close();

            return usuarios.FirstOrDefault(u => u.NombreUsuario == usuario.NombreUsuario);
        }

        public DataTable ExecuteStoredProcedure(int id)
        {

            CommandSender cmdSender = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerProyectosEnEquipoDeProgramador")
                .WithParameter<int>("idUsuario", id)
                .Build();
            SQLConfiguration.Close();
            return _converter.GetDataByStoredProcedure(cmdSender);
        }



        public Usuarios ObtenerEntidadPorId(int idUsuario)
        {
            CommandSender cmdsender = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerCredencialUsuario")
                .WithParameter<int>("idUsuario", idUsuario)
                .Build();

            List<Usuarios> us = _converter.GetAnyDataByCommand<Usuarios>(cmdsender);
            SQLConfiguration.Close();
            return us.LastOrDefault(u => u.idUsuario == idUsuario);
        }


        public List<Usuarios> CallStoredProcedure(Usuarios usuario)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            using (SqlCommand command = new SqlCommand("usp_ValidarUsuario", SQLConfiguration.GetConnection()))
            {
                command.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                command.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = usuario.Password;
                command.CommandType = CommandType.StoredProcedure;
                SQLConfiguration.Open();
                SqlDataReader reader = command.ExecuteReader();
                bool isOk = false;
                while (reader.Read())
                {
                    isOk = bool.Parse(reader["isOk"].ToString());
                   
                }
                if (isOk == false)
                {
                    SQLConfiguration.Close();
                    
                    return null;
                }

                reader.Close();
            }

            usuarios.Add(Find(usuario));
            SQLConfiguration.Close();
            return usuarios;
        }

      
    }
}
