using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DurandalDemo.DAL
{
    public abstract class EntityFrameworkBaseRepository<TEntity, TKey> : IHasModelConfiguration,
        IRepository<TEntity, TKey> where TEntity : class
    {
        protected EntityFrameworkBaseRepository(IProspectContext context)
        {
            Context = context;
        }

        protected IProspectContext Context { get; private set; }

        public virtual IQueryable<TEntity> All
        {
            get { return Context.Set<TEntity>(); }
        }

        public virtual int Create(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            var rowsAfftected = Context.SaveChanges();
            return rowsAfftected;
        }



        public virtual TEntity ById(TKey id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            return entity;
        }

        private IQueryable<TEntity> ById(IEnumerable<TKey> ids)
        {
            throw new NotImplementedException();
            //var entity = Context.Set<TEntity>().Find(id);
            //if(entity is ISoftDelete) if((entity as ISoftDelete).IsDeleted) return null;
            //return entity;
        }


        public virtual int Delete(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);

            Context.Set<TEntity>().Remove(entity);
            var rowsAffected = Context.SaveChanges();
            return rowsAffected;
        }



        public virtual int Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            var rowsAffected = Context.SaveChanges();
            return rowsAffected;
        }



        protected void AttachDetachedCollection<T>(ICollection<T> entities) where T : class
        {
            foreach (T entity in entities)
            {
                Context.Set<T>().Attach(entity);
                Context.Entry(entity).State = EntityState.Unchanged;
            }
        }

        public void Attach(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
        }
        internal void Attach(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
            // Context.Set<TEntity>().Attach(entities);
        }

        internal delegate void EntityEvent(TEntity entity);



        public int Create(ICollection<TEntity> entities)
        {
            Attach(entities);
            return Context.SaveChanges();
        }

        public int Delete(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }






        public int SaveChanges()
        {
            return Context.SaveChanges();
        }


    }
}
