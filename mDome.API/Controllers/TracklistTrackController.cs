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
    public class TracklistTrackController : BaseCRUDController<Model.TracklistTrack, TracklistTrackSearchRequest, TracklistTrackUpsertRequest, TracklistTrackUpsertRequest>
    {
        public TracklistTrackController(ICRUDService<TracklistTrack, TracklistTrackSearchRequest, TracklistTrackUpsertRequest, TracklistTrackUpsertRequest> service) : base(service)
        {
        }
    }
}
