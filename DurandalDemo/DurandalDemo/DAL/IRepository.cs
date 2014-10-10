using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DurandalDemo.DAL
{
    public interface IRepository { }

    public interface IRepository<TEntity, in TKey> : IRepository where TEntity : class
    {
        TEntity ById(TKey id);
        int Create(TEntity entity); //returns Rows Affected
        int Create(ICollection<TEntity> entity); //returns Rows Affected
        int Update(TEntity entity); //returns Rows Affected
        int Delete(TEntity entity); //returns Rows Affected
        void Attach(TEntity entity); //returns Rows Affected
        int Delete(ICollection<TEntity> entities); //returns Rows Affected
        IQueryable<TEntity> All { get; }
        int SaveChanges();

    }

 

}
