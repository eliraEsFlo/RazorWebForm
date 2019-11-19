using Backend.Infrastructura.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.Infrastructura.TableServices
{
    public class EstadosDeRequerimientoTable : IRepository<EstadosDeRequerimiento>
    {
        public void Add(EstadosDeRequerimiento entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<EstadosDeRequerimiento> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadosDeRequerimiento> Find(Expression<Func<EstadosDeRequerimiento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<EstadosDeRequerimiento> GetAll()
        {
            throw new NotImplementedException();
        }

        public EstadosDeRequerimiento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(EstadosDeRequerimiento entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(EstadosDeRequerimiento entities)
        {
            throw new NotImplementedException();
        }
    }
}
