using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.Infrastructura.Interfaces
{
    public interface IReadDataRepository<T>  where T : class
    {
        T GetById(int id);

        ICollection<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    }
}
