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
    public class LoginLogTableController : BaseCRUDController<Model.LoginLogTable, LoginLogSearchRequest, LoginLogUpsertRequest, LoginLogUpsertRequest>
    {
        public LoginLogTableController(ICRUDService<LoginLogTable, LoginLogSearchRequest, LoginLogUpsertRequest, LoginLogUpsertRequest> service) : base(service)
        {
        }
    }
}
