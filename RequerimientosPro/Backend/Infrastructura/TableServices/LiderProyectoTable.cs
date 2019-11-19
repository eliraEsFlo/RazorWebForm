using Backend.Infrastructura.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Backend.Infrastructura.TableServices
{
    public class LiderProyectoTable : IRepository<LiderProyecto>
    {
        public void Add(LiderProyecto entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LiderProyecto> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LiderProyecto> Find(Expression<Func<LiderProyecto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<LiderProyecto> GetAll()
        {
            List<LiderProyecto> lideres = new List<LiderProyecto>();
            
            using (SqlCommand command = new SqlCommand("usp_ObtenerLiderProyecto",
                 SQLConfiguration.GetConnection()))
            {

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lideres.Add(new LiderProyecto()
                    {
                        idLiderProyecto = Int32.Parse(reader["idLiderProyecto"].ToString()),
                        idUsuario = Int32.Parse(reader["idUsuario"].ToString()),
                    });
                }

                command.Dispose();
            }

            return lideres;
        }

        public LiderProyecto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(LiderProyecto entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(LiderProyecto entities)
        {
            throw new NotImplementedException();
        }
    }
}
