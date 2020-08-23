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
    public class UserTrackVoteController : BaseCRUDController<Model.UserTrackVote, UserTrackVoteSearchRequest, UserTrackVoteUpsertRequest, UserTrackVoteUpsertRequest>
    {
        public UserTrackVoteController(ICRUDService<UserTrackVote, UserTrackVoteSearchRequest, UserTrackVoteUpsertRequest, UserTrackVoteUpsertRequest> service) : base(service)
        {
        }
    }
}
