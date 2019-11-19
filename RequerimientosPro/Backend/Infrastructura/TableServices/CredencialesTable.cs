
using Backend.Infrastructura.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.Infrastructura.TableServices
{
    public class CredencialesTable : IRepository<Credenciales>
    {
        public void Add(Credenciales entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Credenciales> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Credenciales> Find(Expression<Func<Credenciales, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Credenciales> GetAll()
        {
            throw new NotImplementedException();
        }

        public Credenciales GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Credenciales entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(Credenciales entities)
        {
            throw new NotImplementedException();
        }
    }
}
