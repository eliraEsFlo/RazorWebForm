using Backend.Infrastructura.Interfaces;
using Backend.Infrastructura.ProcedimientosAlmacenados.Command;
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
        SqlStoredProcedureServiceManager _storedProcedureService;
        public LiderProyectoTable()
        {
            _storedProcedureService = new SqlStoredProcedureServiceManager();
        }
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

            CommandSender cmd = new CommandSender.Builder()
                .SetProcedureName("usp_ObtenerLiderProyecto")
                .Build();

            lideres = _storedProcedureService.GetAnyDataByCommand<LiderProyecto>(cmd);

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
