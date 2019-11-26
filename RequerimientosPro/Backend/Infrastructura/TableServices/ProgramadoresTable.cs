using Backend.Infrastructura.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Backend.Infrastructura.TableServices
{
    public class ProgramadoresTable : IRepository<Usuarios>
    {
        private readonly Dictionary<string, string> procedimientos = new Dictionary<string, string>();

        public ProgramadoresTable()
        {
            procedimientos.Add("ObtenerUsuarios", "usp_ObtenerUsuarios");
            procedimientos.Add("ValidarUsuario", "usp_ValidarUsuario");
        }

        public SQLConfiguration dataContext;

        public void Add(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Usuarios> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuarios> Find(Expression<Func<Usuarios, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Usuarios> GetAll()
        {
            List<Usuarios> usuariosConId = new List<Usuarios>();

            using (SqlCommand command = new SqlCommand("usp_ObtenerUsuarios",
                  SQLConfiguration.GetConnection()) )
            {
                
                command.CommandType = CommandType.StoredProcedure;
                SQLConfiguration.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuariosConId.Add
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
            SQLConfiguration.Close();
            return usuariosConId;
        }

        public Usuarios GetById(int id)
        {
            List<Usuarios> us = (List<Usuarios>) GetAll();
            return us.Find(u => u.idUsuario == id); 
        }

        public void Remove(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(Usuarios entities)
        {
            throw new NotImplementedException();
        }
    }
}
