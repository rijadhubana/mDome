using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mDome.API.Services;
using mDome.Model;
using mDome.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mDome.API.Controllers
{
    public class RequestController : BaseCRUDController<Model.Request, RequestSearchRequest, RequestUpsertRequest, RequestUpsertRequest>
    {
        public RequestController(ICRUDService<Request, RequestSearchRequest, RequestUpsertRequest, RequestUpsertRequest> service) : base(service)
        {
        }
    }
}
