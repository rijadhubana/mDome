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
    public class UserCommentPostController : BaseCRUDController<Model.UserCommentPost, UserCommentPostSearchRequest, UserCommentPostUpsertRequest, UserCommentPostUpsertRequest>
    {
        public UserCommentPostController(ICRUDService<UserCommentPost, UserCommentPostSearchRequest, UserCommentPostUpsertRequest, UserCommentPostUpsertRequest> service) : base(service)
        {
        }
    }
}
