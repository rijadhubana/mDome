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
    public class TrackController : BaseCRUDController<Model.Track, TrackSearchRequest, TrackUpsertRequest, TrackUpsertRequest>
    {
        public TrackController(ICRUDService<Track, TrackSearchRequest, TrackUpsertRequest, TrackUpsertRequest> service) : base(service)
        {
        }
    }
}
