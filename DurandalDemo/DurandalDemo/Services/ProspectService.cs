using DurandalDemo.Command;
using DurandalDemo.DAL;
using DurandalDemo.Models;
using DurandalDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DurandalDemo.Extensions;
namespace DurandalDemo.Services
{
    public interface IProspectService : IDataService<Prospect, Guid, ProspectUpdateCommand, ProspectCreateCommand, ProspectDeleteCommand>
    {
        ProspectViewModel byId(Guid prospectID);
        IQueryable<Prospect> ProspectByName(string prospectName);
    }

    public class ProspectService : DataServiceBase<Prospect, Guid, ProspectUpdateCommand, ProspectCreateCommand, ProspectDeleteCommand>, IProspectService
    {
        private readonly IProspectRepository _prospectRepository;

        public ProspectService(IProspectRepository prospectRepository)
        {
            _prospectRepository = prospectRepository;
        }

        protected override IRepository<Prospect, Guid> Repository
        {
            get { return _prospectRepository; }
        }

        public override DataExecutionResult<Prospect> Execute(ProspectCreateCommand command)
        {
            var entity = command.ToEntity();
            var result = _prospectRepository.Create(entity);
            if (result > 0)
            {
                return new DataExecutionResult<Prospect>() { Entity = entity, RowsAffected = 1 };
            }
            else
            {
                return new DataExecutionResult<Prospect>() { RowsAffected = 0, Errors = new List<string>() { "Error Occurred while creating." } };
            }
        }

        public override Prospect CommandToEntity(ProspectCreateCommand command)
        {
            throw new NotImplementedException();
        }

        public override Prospect CommandToEntity(ProspectUpdateCommand command, Prospect entity)
        {
            _prospectRepository.Update(command.ToEntity(_prospectRepository.ById(command.ID)));
            return command.ToEntity(entity);
        }

        public IQueryable<Prospect> ProspectByName(string name)
        {
            return _prospectRepository.ProspectByName(name);
        }

        
        public new ProspectViewModel byId(Guid id)
        {
            return _prospectRepository.byId(id).ToProspectViewModels();
        }

    }
}