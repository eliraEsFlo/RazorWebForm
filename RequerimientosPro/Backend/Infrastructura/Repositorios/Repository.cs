using Backend.Infrastructura.ContextoDatos;
using Backend.Infrastructura.Entities;
using Backend.Infrastructura.Interfaces;
using System;
using System.Collections.Generic;

namespace Backend.Infrastructura.Repositorios
{
    public class Repository<T> : IRepository<T> where T: class
    {
        
        IRepository<T> dbset;

        public Repository(IRepository<T> tableService)
        {
            dbset = tableService;
        }


        public IEnumerable<T> GetAll()
        {
            return dbset.GetAll();
        }


        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(T entities)
        {
            throw new NotImplementedException();
        }
    }
}
