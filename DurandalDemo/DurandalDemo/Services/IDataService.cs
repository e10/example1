using DurandalDemo.Command;
using System;
using System.Linq;
using System.Web;

namespace DurandalDemo.Services
{
    public interface IDataService<out TEntity> : IService
        where TEntity : class
    {
        IQueryable<TEntity> All { get; }
    }

    public interface IDataService<TEntity, TKey, in TUpdate, in TCreate, in TDelete> : IDataService<TEntity>,
        ICreateHandler<TEntity, TCreate>,
        IDeleteHandler<TKey, TDelete>,
        IUpdateHandler<TEntity, TKey, TUpdate>
        where TEntity : class
        where TUpdate : IUpdateCommand<TKey>
        where TDelete : IDeleteCommand<TKey>
        where TCreate : ICreateCommand
    { }
}