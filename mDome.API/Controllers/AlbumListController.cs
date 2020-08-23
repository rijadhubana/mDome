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
    public class AlbumListController : BaseCRUDController<Model.AlbumList, AlbumListSearchRequest, AlbumListUpsertRequest, AlbumListUpsertRequest>
    {
        public AlbumListController(ICRUDService<AlbumList, AlbumListSearchRequest, AlbumListUpsertRequest, AlbumListUpsertRequest> service) : base(service)
        {
        }
    }
}
