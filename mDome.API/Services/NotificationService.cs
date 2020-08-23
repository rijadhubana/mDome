using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class NotificationService : BaseCRUDService<Model.Notification, NotificationSearchRequest, Database.Notification, NotificationUpsertRequest, NotificationUpsertRequest>
    {
        public NotificationService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Notification> Get(NotificationSearchRequest search)
        {
            var query = _context.Notification.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(a => a.UserId == search.UserId);
            }
            
            var list = query.ToList();
            return _mapper.Map<List<Model.Notification>>(list);
        }
    }
}
