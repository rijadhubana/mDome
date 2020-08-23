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
    public class AdministratorLoginController : BaseCRUDController<Model.AdministratorLogin, AdminSearchRequest, AdminUpsertRequest, AdminUpsertRequest>
    {
        public AdministratorLoginController(ICRUDService<AdministratorLogin, AdminSearchRequest, AdminUpsertRequest, AdminUpsertRequest> service) : base(service)
        {
        }
    }
}
