using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;


namespace HSIME.Data.Repository.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private IRepositoryContext _repositoryContext;

        private IObjectSet<T> _objectSet;

        public BaseRepository() : this(new RepositoryContext()) { }

        public BaseRepository(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext = repositoryContext ?? new RepositoryContext();
            _objectSet = _repositoryContext.GetObjectSet<T>();
        }

        public IRepositoryContext RepositoryContext
        {
            get
            {
                return this._repositoryContext;
            }
        }

        public IObjectSet<T> ObjectSet
        {
            get
            {
                return _objectSet;
            }
        }

        public void Add(T entity)
        {
            this.ObjectSet.AddObject(entity);
            this.RepositoryContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _repositoryContext.ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
            this.ObjectSet.DeleteObject(entity);
            this.RepositoryContext.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return this.ObjectSet.ToList<T>();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).ToList<T>();
        }

        public T GetSingle(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).FirstOrDefault<T>();
        }

        public void Attach(T entity)
        {
            this.ObjectSet.Attach(entity);
        }

        public void Update(T Entity)
        {
            // ObjectSet.AddObject(Entity);
            _repositoryContext.ObjectContext.ObjectStateManager.ChangeObjectState(Entity, EntityState.Modified);
            _repositoryContext.SaveChanges();
        }

        public void SaveChanges()
        {
            this.RepositoryContext.SaveChanges();
        }

        public IQueryable<T> GetQueryable()
        {
            return this.ObjectSet.AsQueryable<T>();
        }

        public long Count()
        {
            return this.ObjectSet.LongCount<T>();
        }

        public long Count(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).LongCount<T>();
        }
    }
}
