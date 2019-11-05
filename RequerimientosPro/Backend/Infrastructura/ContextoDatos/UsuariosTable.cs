namespace Infrastructura.ContextoDatos
{
    public class UsuariosTable
    {  /*ILectorDeCodigoSql<Usuario>
    {
      
        public List<Usuario> ToList()
        {
            List<Usuario> empleados = new List<Usuario>();
            using (SQLConfiguration instance = new SQLConfiguration())
            {
                instance.OpenConnection();

                SqlCommand command = new SqlCommand("usp_LeerUsuarios", instance.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    empleados.Add(new Usuario()
                    {
                         idUsuario = reader.GetInt32(0),
                        NombreUsuario = reader.GetString(1)
                    });
                }
            }

            return empleados;
        }


        public int FindUser(Usuario user)
        {

            SQLConfiguration instance = new SQLConfiguration();
            instance.OpenConnection();

            SqlCommand command = new SqlCommand("usp_ValidarUsuario", instance.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = user.NombreUsuario;
            command.Parameters.Add("@passWord", SqlDbType.VarChar, 50).Value = user.UserPasssword;
            SqlDataReader reader = command.ExecuteReader();

            int wasFound = 0;
            while (reader.Read())
            {
                wasFound = reader.GetInt32(0);
            }

            return wasFound;
        }
    }

    */
    }
}
