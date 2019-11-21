using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructura.ProcedimientosAlmacenados
{
    
    public interface IStoredProcedureWrititer<T>
    {
        List<T> CallStoredProcedure(T entity);
        T ObtenerEntidadPorId(int id);

        DataTable ExecuteStoredProcedure(int data);
    }

}
