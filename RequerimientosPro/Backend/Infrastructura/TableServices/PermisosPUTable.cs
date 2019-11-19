using Backend.Infrastructura.Interfaces;
using Backend.Infrastructura.TableServices.DataArtifacts;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Backend.Infrastructura.TableServices
{
    public class PermisosPUTable : IRepository<PermisosDePUTable>, IStoredProceduresConfigurator
    {
        
        public PermisosPUTable()
        {
            
        }

        public Dictionary<string, string> procedimientoAlmacenados { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(PermisosDePUTable entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<PermisosDePUTable> entities)
        {
            throw new NotImplementedException();
        }


        public string GetProcedure(string alias)
        {
            throw new NotImplementedException();
        }


        public void AddStoreProcedure(string alias, string storedProcedure)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PermisosDePUTable> Find(Expression<Func<PermisosDePUTable, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<PermisosDePUTable> GetAll()
        {
            List<PermisosDePUTable> permisosDePU = new List<PermisosDePUTable>();

            
                SqlCommand command = new SqlCommand("usp_ObtenerPermisosDePU",
                    SQLConfiguration.GetConnection() );

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    permisosDePU.Add
                    (
                        new PermisosDePUTable()
                        {
                            idPermisoPU = (int)reader["idPermisoPU"],
                            NombrePermiso = reader["NombrePermiso"].ToString()
                        }
                    );
                }

         
            return permisosDePU;
        }

        public PermisosDePUTable GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(PermisosDePUTable entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(PermisosDePUTable entities)
        {
            throw new NotImplementedException();
        }
    }
}
