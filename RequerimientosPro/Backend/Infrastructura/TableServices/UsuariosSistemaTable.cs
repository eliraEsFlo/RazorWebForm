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

    public class UsuariosSistemaTable : IRepository<Usuarios>
    {
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
            throw new NotImplementedException();
        }

        public Usuarios GetById(int id)
        {
            throw new NotImplementedException();
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
