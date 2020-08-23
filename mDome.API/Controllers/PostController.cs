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
    public class PostController : BaseCRUDController<Model.Post, PostSearchRequest, PostUpsertRequest, PostUpsertRequest>
    {
        public PostController(ICRUDService<Post, PostSearchRequest, PostUpsertRequest, PostUpsertRequest> service) : base(service)
        {
        }
    }
}
