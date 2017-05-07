using System.Data.Entity.Core.Objects;

namespace HSIME.Data.Repository.Base
{
   public interface IRepositoryContext
    {
        IObjectSet<T> GetObjectSet<T>() where T : class;
        ObjectContext ObjectContext { get; }
        int SaveChanges();
        void Terminate();
    }
}
