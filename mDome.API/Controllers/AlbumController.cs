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
    public class AlbumController : BaseCRUDController<Model.Album, AlbumSearchRequest, AlbumUpsertRequest, AlbumUpsertRequest>
    {
        public AlbumController(ICRUDService<Album, AlbumSearchRequest, AlbumUpsertRequest, AlbumUpsertRequest> service) : base(service)
        {
        }
    }
}
