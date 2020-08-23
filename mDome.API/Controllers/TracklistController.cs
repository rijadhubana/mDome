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
    public class TracklistController : BaseCRUDController<Model.Tracklist, TracklistSearchRequest, TracklistUpsertRequest, TracklistUpsertRequest>
    {
        public TracklistController(ICRUDService<Tracklist, TracklistSearchRequest, TracklistUpsertRequest, TracklistUpsertRequest> service) : base(service)
        {
        }
    }
}
