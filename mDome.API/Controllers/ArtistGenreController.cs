using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using mDome.API.Database;
using mDome.API.Services;
using mDome.Model;
using mDome.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mDome.API.Controllers
{
    public class ArtistGenreController : BaseCRUDController<Model.ArtistGenre, ArtistGenreSearchRequest, ArtistGenreUpsertRequest, ArtistGenreUpsertRequest>
    {
        public ArtistGenreController(ICRUDService<Model.ArtistGenre, ArtistGenreSearchRequest, ArtistGenreUpsertRequest, ArtistGenreUpsertRequest> service) : base(service)
        {
        }
    }
}
