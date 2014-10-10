using System;
using System.Linq;
using DurandalDemo.Models;

namespace DurandalDemo.DAL
{
    public interface IProspectRepository : IRepository<Prospect, Guid>
    {
        IQueryable<Prospect> ByName(string prospectName);
    }
}