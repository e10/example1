using DurandalDemo.Command;
using DurandalDemo.Models;
using DurandalDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DurandalDemo.Extensions
{
    public static class ProspectExtensions
    {

        public static ProspectCreateCommand ToCommand(this ProspectCreateViewModel model)
        {
            return new ProspectCreateCommand()
            
            {
                ProspectID = Guid.NewGuid(),
                ProspectName = model.ProspectName,
                ProspectType = model.ProspectType,
                Closed = model.Closed,
                AdditionalInfo = model.AdditionalInfo
            };
        }

        public static ProspectUpdateCommand ToCommand(this ProspectEditViewModel model)
        {
            return new ProspectUpdateCommand()
            {
                ID = model.ProspectID,
                ProspectName = model.ProspectName,
                ProspectType = model.ProspectType,
                Closed = model.Closed,
                AdditionalInfo = model.AdditionalInfo
            };
        }

        public static IQueryable<ProspectGridViewModel> ToProspectGridViewModels(this IQueryable<Prospect> query)
        {
            var result = from x in query
                         select new ProspectGridViewModel
                         {
                             ProspectID = x.ProspectID,
                             ProspectName = x.ProspectName,
                             ProspectType = ((ProspectType)x.ProspectType).ToString(),
                             Closed = x.Closed,
                             AdditionalInfo = x.AdditionalInfo
                         };
            return result;
        }

        public static IQueryable<ProspectViewModel> ToProspectViewModels(this IQueryable<Prospect> query)
        {
            var result = from x in query
                         select new ProspectViewModel
                         {
                             ProspectID = x.ProspectID,
                             ProspectName = x.ProspectName,
                             ProspectType = ((ProspectType)x.ProspectType).ToString(),
                             Closed = x.Closed,
                             AdditionalInfo = x.AdditionalInfo
                         };
            return result;
        }

        public static ProspectViewModel ToProspectViewModels(this Prospect x)
        {
            var result = new ProspectViewModel
            {
                ProspectID = x.ProspectID,
                ProspectName = x.ProspectName,
                ProspectType = Enum.Parse(typeof(ProspectType), x.ProspectType.ToString()).ToString(),
                Closed = x.Closed,
                AdditionalInfo = x.AdditionalInfo
            };
            return result;
        }


        public static Prospect ToEntity(this ProspectCreateCommand command)
        {
            return new Prospect()
            {
                ProspectID=command.ProspectID,
                ProspectName = command.ProspectName,
                ProspectType = command.ProspectType,
                Closed = command.Closed,
                AdditionalInfo = command.AdditionalInfo
            };
        }

        public static Prospect ToEntity(this ProspectUpdateCommand command, Prospect entity)
        {
            entity.ProspectName = command.ProspectName;
            entity.ProspectType = command.ProspectType;
            entity.Closed = command.Closed;
            entity.AdditionalInfo = command.AdditionalInfo;
            return entity;
        }


    }
}