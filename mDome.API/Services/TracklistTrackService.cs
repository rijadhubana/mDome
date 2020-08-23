using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class TracklistTrackService : BaseCRUDService<Model.TracklistTrack, TracklistTrackSearchRequest, Database.TracklistTrack, TracklistTrackUpsertRequest, TracklistTrackUpsertRequest>
    {
        public TracklistTrackService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.TracklistTrack> Get(TracklistTrackSearchRequest search)
        {
            var query = _context.TracklistTrack.AsQueryable();
            if (search.TrackId.HasValue)
            {
                query = query.Where(x => x.TrackId == search.TrackId);
            }
            if (search.TracklistId.HasValue)
            {
                query = query.Where(x => x.TracklistId == search.TracklistId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.TracklistTrack>>(list);
        }
        public override Model.TracklistTrack Update(int id, TracklistTrackUpsertRequest request)
        {
            var entity = _context.TracklistTrack.Where(a => a.TrackId == request.TrackId && a.TracklistId == request.TracklistId).FirstOrDefault();
            _context.TracklistTrack.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.TracklistTrack>(entity);
        }
    }
}
