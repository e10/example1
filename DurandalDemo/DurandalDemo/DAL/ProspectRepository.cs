using DurandalDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DurandalDemo.DAL
{

    public interface IProspectRepository : IRepository<Prospect, Guid>
    {
        Prospect byId(Guid prospectID);
        IQueryable<Prospect> ProspectByName(string prospectName);
    }

    public class ProspectRepository : EntityFrameworkBaseRepository<Prospect, Guid>, IProspectRepository
    {

        public ProspectRepository(ProspectContext context)
            : base(context)
        {
        }

        public override IQueryable<Prospect> All
        {
            get
            {
                return base.All;
            }
        }

        public Prospect byId(Guid prospectID)
        {
            return All.FirstOrDefault(x => x.ProspectID == prospectID);
        }

        public IQueryable<Prospect> ProspectByName(string prospectName)
        {
            return All.Where(x => x.ProspectName == prospectName);
        }

    }
}