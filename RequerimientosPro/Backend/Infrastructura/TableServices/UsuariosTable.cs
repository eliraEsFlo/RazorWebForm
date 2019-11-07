using Backend.Infrastructura.Entities;
using Backend.Infrastructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructura.TableServices
{
    public class UsuariosTable : IRepository<Programadores>
    {
        Dictionary<string, string> procedimientos = new Dictionary<string, string>();

        public UsuariosTable()
        {
            procedimientos.Add("ObtenerUsuarios", "usp_ObtenerProgramadoresConId");
        }
        public void Add(Programadores entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Programadores> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Programadores> Find(Expression<Func<Programadores, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Programadores> GetAll()
        {
            List<Programadores> usuariosConId = new List<Programadores>();

            SQLConfiguration sqlInstance = new SQLConfiguration();
            using (SqlCommand command = new SqlCommand(procedimientos["ObtenerUsuarios"], sqlInstance.GetConnection()) )
            {
                sqlInstance.OpenConnection();
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuariosConId.Add
                    (
                        new Programadores()
                        {
                            idUsuario = (int)reader["idUsuario"],
                            NombreUsuario = reader["NombreUsuario"].ToString(),
                            Estado = bool.Parse(reader["Estado"].ToString())
                        }
                    );
                }

                sqlInstance.Dispose();
            }
            return usuariosConId;
        }

        public Programadores GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Programadores entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(Programadores entities)
        {
            throw new NotImplementedException();
        }
    }
}
