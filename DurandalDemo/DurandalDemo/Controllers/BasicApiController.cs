using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
//using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using Newtonsoft.Json;

namespace DurandalDemo.Controllers
{
    public abstract class BasicApiController : ApiController {
        protected HttpResponseMessage HttpResponseMessage(HttpStatusCode status) {
            return new HttpResponseMessage(status);
        }
        protected HttpResponseMessage HttpResponseMessage<T>(T model, HttpStatusCode status) {
            var msg = new HttpResponseMessage(status)
            {
                Content = new ObjectContent<T>(model, new System.Net.Http.Formatting.JsonMediaTypeFormatter())
            };
            return msg;
        }
        protected HttpResponseMessage Created<T>(T val, string newUri = "") {
            return Request.CreateResponse(HttpStatusCode.Created, val);
        }
        protected HttpResponseMessage Accepted<T>(T val) {
            return Request.CreateResponse(HttpStatusCode.Accepted, val);
        }
        protected HttpResponseMessage Ok<T>(T val) {
            return Request.CreateResponse(HttpStatusCode.OK, val);
        }
        protected HttpResponseMessage Error(Exception ex, string newUri = "") {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message, ex.StackTrace });
        }
        protected HttpResponseMessage Bad(string msg = "") {
            return Request.CreateResponse(HttpStatusCode.BadRequest, msg);
        }
        protected HttpResponseMessage NotFound(string msg = "") {
            return Request.CreateResponse(HttpStatusCode.NotFound, msg);
        }
        protected HttpResponseMessage Bad(object obj)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(obj));
        }
        
        protected HttpResponseMessage BadRaw(object obj)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest,obj);
        }
        protected HttpResponseMessage Created<T>(T val, Uri newUri) {
            return Request.CreateResponse(HttpStatusCode.Created, val);
        }
        protected HttpResponseMessage UnAuthorized<T>(T val) {
            return Request.CreateResponse(HttpStatusCode.Unauthorized, val);
        }
        
        protected PageResult<T> Page<T>(IQueryable<T> query, ODataQueryOptions<T> options) {
            IQueryable results = options.ApplyTo(query, new ODataQuerySettings() { PageSize = options.Top==null ? 20 : (options.Top.Value>200?200:options.Top.Value) });
            return new PageResult<T>(results as IEnumerable<T>, Request.GetNextPageLink(), Request.GetInlineCount());
        }
    }

}