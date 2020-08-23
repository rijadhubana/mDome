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
    public class GenreController : BaseCRUDController<Model.Genre, GenreSearchRequest, GenreUpsertRequest, GenreUpsertRequest>
    {
        public GenreController(ICRUDService<Genre, GenreSearchRequest, GenreUpsertRequest, GenreUpsertRequest> service) : base(service)
        {
        }
    }
}
