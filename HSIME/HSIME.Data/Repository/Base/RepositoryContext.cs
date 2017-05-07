using System.Data.Entity.Core.Objects;

namespace HSIME.Data.Repository.Base
{
    public class RepositoryContext : IRepositoryContext
    {
        private const string OBJECT_CONTEXT_KEY = "HomesScapesOnline";


        public IObjectSet<T> GetObjectSet<T>()
            where T : class
        {
            return ContextManager.GetObjectContext(OBJECT_CONTEXT_KEY).CreateObjectSet<T>();
        }

        /// <summary>
        /// Returns the active object context
        /// </summary>
        public ObjectContext ObjectContext
        {
            get
            {
                return ContextManager.GetObjectContext(OBJECT_CONTEXT_KEY);
            }
        }

        public int SaveChanges()
        {
            return this.ObjectContext.SaveChanges();
        }

        public void Terminate()
        {
            ContextManager.SetRepositoryContext(null, OBJECT_CONTEXT_KEY);
        }

        
    }
}
