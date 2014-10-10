using DurandalDemo.Command;
using DurandalDemo.Extensions;
using DurandalDemo.Models;
using DurandalDemo.Services;
using DurandalDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace DurandalDemo.Controllers
{
    [RoutePrefix("api/prospect")]
    public class ProspectController : BasicApiController
    {
        private readonly IProspectService _service;
        public ProspectController(IProspectService service)
        {
            _service = service;
        }

        [HttpGet, Route]
        public PageResult<ProspectGridViewModel> GetAsOData(ODataQueryOptions<ProspectGridViewModel> options)
        {
            return Page(_service.All.ToProspectGridViewModels(), options);
        }

        [HttpGet, Route("all")]
        public IQueryable<ProspectViewModel> GetAll()
        {
            return _service.All.ToProspectViewModels();
        }

        [HttpPost, Route]
        public HttpResponseMessage Post(ProspectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _service.Execute(model.ToCommand());
                return Accepted(new { created = item.RowsAffected, errors = item.Errors });
            }
            return Bad(ModelState);
        }

        [HttpPut, Route]
        public HttpResponseMessage Put(ProspectEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _service.Execute(model.ToCommand());
                return Accepted(item);
            }
            return Bad(ModelState);
        }

        [HttpGet, Route("{id}")]
        public ProspectViewModel Get([FromUri]Guid id)
        {
            return _service.byId(id);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage Delete([FromUri]Guid id)
        {
            if (ModelState.IsValid)
            {
                var item = _service.Execute(new ProspectDeleteCommand() { ID = id });
                return Accepted(item);
            }
            return Bad(ModelState);
        }

        [HttpGet, Route("prospectname")]
        public IQueryable<ProspectViewModel> Get(string username)
        {
            var item = _service.ProspectByName(username).ToProspectViewModels();
            return item;
        }

        [HttpGet, Route("prospecttype")]
        public IList<EnumProspectType> GetTypes()
        {
            var texts = Enum.GetValues(typeof(ProspectType));
            return (from object text in texts let value = (int) Enum.Parse(typeof (ProspectType), text.ToString()) select new EnumProspectType {ID = value, Label = text.ToString()}).ToList();
        }

        public class EnumProspectType
        {
            public int ID { get; set; }
            public string Label { get; set; }
        }
    }
}
