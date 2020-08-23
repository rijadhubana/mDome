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
    public class ReviewController : BaseCRUDController<Model.Review, ReviewSearchRequest, ReviewUpsertRequest, ReviewUpsertRequest>
    {
        public ReviewController(ICRUDService<Review, ReviewSearchRequest, ReviewUpsertRequest, ReviewUpsertRequest> service) : base(service)
        {
        }
    }
}
