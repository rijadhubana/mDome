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
    public class UserFollowsArtistController : BaseCRUDController<Model.UserFollowsArtist, UserFollowsArtistSearchRequest, UserFollowsArtistUpsertRequest, UserFollowsArtistUpsertRequest>
    {
        public UserFollowsArtistController(ICRUDService<UserFollowsArtist, UserFollowsArtistSearchRequest, UserFollowsArtistUpsertRequest, UserFollowsArtistUpsertRequest> service) : base(service)
        {
        }
    }
}
