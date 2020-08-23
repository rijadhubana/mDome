using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mDome.API.Database;
using mDome.API.Services;
using mDome.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mDome.API.Controllers
{
    public class UserLikePostController : BaseCRUDController<Model.UserLikePost, UserLikePostSearchRequest, UserLikePostUpsertRequest, UserLikePostUpsertRequest>
    {
        public UserLikePostController(ICRUDService<Model.UserLikePost, UserLikePostSearchRequest, UserLikePostUpsertRequest, UserLikePostUpsertRequest> service) : base(service)
        {
        }
    }
}
