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
    public class UserProfileController : BaseCRUDController<Model.UserProfile, UserProfileSearchRequest, UserProfileUpsertRequest, UserProfileUpsertRequest>
    {
        public UserProfileController(ICRUDService<UserProfile, UserProfileSearchRequest, UserProfileUpsertRequest, UserProfileUpsertRequest> service) : base(service)
        {
        }
    }
}
