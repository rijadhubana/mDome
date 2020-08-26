using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class RequestService : BaseCRUDService<Model.Request, RequestSearchRequest, Database.Request, RequestUpsertRequest, RequestUpsertRequest>
    {
        public RequestService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Request> Get(RequestSearchRequest search)
        {
            var query = _context.Request.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.RequestText))
            {
                query = query.Where(x => x.RequestText.Contains(search.RequestText));
            }
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            query = query.OrderBy(x => x.RequestDate);
            var list = query.ToList();
            return _mapper.Map<List<Model.Request>>(list);
        }
    }
}
