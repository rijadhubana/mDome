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
    public class NotificationController : BaseCRUDController<Model.Notification, NotificationSearchRequest, NotificationUpsertRequest, NotificationUpsertRequest>
    {
        public NotificationController(ICRUDService<Notification, NotificationSearchRequest, NotificationUpsertRequest, NotificationUpsertRequest> service) : base(service)
        {
        }
    }
}
