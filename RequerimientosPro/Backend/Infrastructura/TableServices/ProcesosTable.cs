using Backend.Infrastructura.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.Infrastructura.TableServices
{
    public class ProcesosTable : IRepository<Procesos>
    {
        public void Add(Procesos entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Procesos> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Procesos> Find(Expression<Func<Procesos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Procesos> GetAll()
        {
            throw new NotImplementedException();
        }

        public Procesos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Procesos entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(Procesos entities)
        {
            throw new NotImplementedException();
        }
    }
}
