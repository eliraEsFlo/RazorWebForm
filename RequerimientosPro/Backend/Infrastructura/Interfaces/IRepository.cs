using System.Collections.Generic;

namespace Backend.Infrastructura.Interfaces
{
    public interface IRepository<T> : IReadDataRepository<T>,
        IWrittebleData<T> where T : class  
    {
      
    }
}
