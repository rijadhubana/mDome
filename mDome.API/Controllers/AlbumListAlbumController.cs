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
    public class AlbumListAlbumController : BaseCRUDController<Model.AlbumListAlbum, AlbumListAlbumSearchRequest, AlbumListAlbumUpsertRequest, AlbumListAlbumUpsertRequest>
    {
        public AlbumListAlbumController(ICRUDService<AlbumListAlbum, AlbumListAlbumSearchRequest, AlbumListAlbumUpsertRequest, AlbumListAlbumUpsertRequest> service) : base(service)
        {
        }
    }
}
