using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public DataTable GetDataSetConStoredProcedure(int id)
        {
            SqlCommand cmd = new SqlCommand("usp_ObtenerProyectosEnEquipoDeProgramador", SQLConfiguration.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public Usuarios ObtenerEntidadPorId(int idUsuario)
        {
            Usuarios usuario = new Usuarios() ;
            using (SqlCommand command = new SqlCommand("usp_ObtenerCredencialUsuario",
                  SQLConfiguration.GetConnection()))
            {

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@idUsuario",SqlDbType.Int).Value = idUsuario;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuario = new Usuarios()
                    {
                        idUsuario = int.Parse(reader["idUsuario"].ToString()),
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        tipoUsuario = reader["DescripcionCredencial"].ToString(),
                        Estado = bool.Parse(reader["Estado"].ToString())
                    };
                }

                SQLConfiguration.Close();
            }
            return usuario;
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
