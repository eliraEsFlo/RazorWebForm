using Core.Entities;

namespace Backend.Infrastructura.ProcedimientosAlmacenados
{


    public interface  IStoredProcedureRepository
    {
        IStoredProcedureWrititer<Usuarios> userStoredProcedures { get; }
    }

    public class StoredProcedureRepository : IStoredProcedureRepository
    {
        public StoredProcedureRepository()
        {
            
        }

        public IStoredProcedureWrititer<Usuarios> userStoredProcedures => new UserStoredProcedure();
    }
}
