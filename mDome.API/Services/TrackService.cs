using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class TrackService : BaseCRUDService<Model.Track, TrackSearchRequest, Database.Track, TrackUpsertRequest, TrackUpsertRequest>
    {
        public TrackService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Track> Get(TrackSearchRequest search)
        {
            var query = _context.Track.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.TrackName))
            {
                query = query.Where(x => x.TrackName.ToLower().Contains(search.TrackName.ToLower()));
            }
            if (search.AlbumId.HasValue)
            {
                query = query.Where(x => x.AlbumId == search.AlbumId);
            }
            query.OrderBy(a => a.TrackNumber);
            var list = query.ToList();
            return _mapper.Map<List<Model.Track>>(list);
        }
        public override Model.Track Delete(int Id)
        {
            _context.TracklistTrack.RemoveRange(_context.TracklistTrack.Where(a => a.TrackId == Id));
            _context.SaveChanges();
            _context.UserTrackVote.RemoveRange(_context.UserTrackVote.Where(a => a.TrackId == Id));
            _context.SaveChanges();
            var entity = _context.Track.Find(Id);
            var x = entity;
            _context.Track.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Track>(x);
        }
    }
}
