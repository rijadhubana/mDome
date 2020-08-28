﻿using System;
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
    public class ArtistController : BaseCRUDController<Model.Artist, ArtistSearchRequest, ArtistUpsertRequest, ArtistUpsertRequest>
    {
        public ArtistController(ICRUDService<Artist, ArtistSearchRequest, ArtistUpsertRequest, ArtistUpsertRequest> service) : base(service)
        {
        }
    }
}