using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using DurandalDemo.Models;
using System.Data.Entity.Validation;

namespace DurandalDemo.DAL
{
    public interface IProspectContextMany : IProspectContext { }

    public interface IProspectContext
    {
        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Database Database { get; }
    }

    public class ProspectContext : DbContext, IProspectContextMany
    {
        public ProspectContext() : this("DBConnection") { currentErrors = new List<string>(); }
        public ProspectContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public DbSet<Prospect> Prospects { get; set; }

        public List<string> currentErrors
        {
            get;
            private set;
        }

        public int SaveChanges()
        {
            try
            {
                currentErrors = new List<string>();
                var i = base.SaveChanges();
                return i;
            }
            catch (DbEntityValidationException ex2)
            {
                var valErrors = GetValidationErrors();
                foreach (var verr in valErrors)
                {
                    currentErrors.Add(verr.Entry.Entity.ToString() + "->");
                    foreach (var err in verr.ValidationErrors)
                    {
                        currentErrors.Add(err.ErrorMessage);
                    }
                }
                throw new Exception(string.Join(",", currentErrors), ex2);
            }
            catch (DbUpdateException bex)
            {
                currentErrors.Add(bex.Message);
                if (bex.InnerException != null)
                {
                    currentErrors.Add(bex.InnerException.Message);
                }
                throw new Exception(string.Join(",", currentErrors), bex);
            }
            catch (System.Data.DataException ex)
            {
                currentErrors.Add(ex.Message);
                throw ex;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}