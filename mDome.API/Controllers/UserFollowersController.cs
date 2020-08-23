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
    public class UserFollowersController : BaseCRUDController<Model.UserFollowers, UserFollowersSearchRequest, UserFollowersUpsertRequest, UserFollowersUpsertRequest>
    {
        public UserFollowersController(ICRUDService<UserFollowers, UserFollowersSearchRequest, UserFollowersUpsertRequest, UserFollowersUpsertRequest> service) : base(service)
        {
        }
    }
}
