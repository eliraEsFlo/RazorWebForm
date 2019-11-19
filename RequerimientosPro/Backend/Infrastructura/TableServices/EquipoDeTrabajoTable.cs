using Backend.Infrastructura.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.Infrastructura.TableServices
{
    public class EquipoDeTrabajoTable : IRepository<EquipoDeTrabajo>
    {
        public void Add(EquipoDeTrabajo entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<EquipoDeTrabajo> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipoDeTrabajo> Find(Expression<Func<EquipoDeTrabajo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<EquipoDeTrabajo> GetAll()
        {
            throw new NotImplementedException();
        }

        public EquipoDeTrabajo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(EquipoDeTrabajo entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(EquipoDeTrabajo entities)
        {
            throw new NotImplementedException();
        }
    }
}
