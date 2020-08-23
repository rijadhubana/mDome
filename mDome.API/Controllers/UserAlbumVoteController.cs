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
    public class UserAlbumVoteController : BaseCRUDController<Model.UserAlbumVote, UserAlbumVoteSearchRequest, UserAlbumVoteUpsertRequest, UserAlbumVoteUpsertRequest>
    {
        public UserAlbumVoteController(ICRUDService<UserAlbumVote, UserAlbumVoteSearchRequest, UserAlbumVoteUpsertRequest, UserAlbumVoteUpsertRequest> service) : base(service)
        {
        }
    }
}
