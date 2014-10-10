using DurandalDemo.Command;
using DurandalDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DurandalDemo.Services
{
    public abstract class DataServiceBase<TEntity, TKey, TUpdate, TCreate, TDelete>
        : IDataService<TEntity, TKey, TUpdate, TCreate, TDelete>
        where TEntity : class
        where TUpdate : IUpdateCommand<TKey>
        where TDelete : IDeleteCommand<TKey>
        where TCreate : ICreateCommand
    {
        protected abstract IRepository<TEntity, TKey> Repository { get; }
        public abstract TEntity CommandToEntity(TCreate command);
        public abstract TEntity CommandToEntity(TUpdate command, TEntity entity);
        public virtual DataExecutionResult<TEntity> Execute(TCreate command)
        {
            return Create(CommandToEntity(command));
        }
        public virtual DataExecutionResult<TEntity> Execute(TUpdate command)
        {
            return Update(CommandToEntity(command, Repository.ById(command.ID)));
        }
        public virtual int Execute(TDelete command)
        {
            return Delete(Repository.ById(command.ID));
        }

        protected virtual DataExecutionResult<TEntity> Update(TEntity entity)
        {
            var rowsAffetced = Repository.Update(entity);
            return new DataExecutionResult<TEntity>() { Entity = entity, RowsAffected = rowsAffetced };
        }

        protected virtual DataExecutionResult<TEntity> Create(TEntity entity)
        {
            var rowsAffetced = Repository.Create(entity);
            return new DataExecutionResult<TEntity>() { Entity = entity, RowsAffected = rowsAffetced };
        }

        protected virtual int Delete(TEntity entity)
        {
            return Repository.Delete(entity);
        }

        public virtual IQueryable<TEntity> All
        {
            get { return Repository.All; }
        }
        
    }
}