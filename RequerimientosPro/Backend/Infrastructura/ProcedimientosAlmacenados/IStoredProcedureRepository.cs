using Core.Entities;

namespace Backend.Infrastructura.ProcedimientosAlmacenados
{


    public interface  IStoredProcedureRepository
    {
        IStoredProcWritter<Usuarios> userStoredProcedures { get; }
    }

    public class StoredProcedureRepository : IStoredProcedureRepository
    {
        public StoredProcedureRepository()
        {
            
        }

        public IStoredProcWritter<Usuarios> userStoredProcedures => new UserStoredProcedure();
    }
}
