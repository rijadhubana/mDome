using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class UserTrackVoteService : BaseCRUDService<Model.UserTrackVote, UserTrackVoteSearchRequest, Database.UserTrackVote, UserTrackVoteUpsertRequest, UserTrackVoteUpsertRequest>
    {
        public UserTrackVoteService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.UserTrackVote> Get(UserTrackVoteSearchRequest search)
        {
            var query = _context.UserTrackVote.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (search.TrackId.HasValue)
            {
                query = query.Where(x => x.TrackId == search.TrackId);
            }
            if (search.Liked.HasValue)
            {
                query = query.Where(x => x.Liked == search.Liked);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.UserTrackVote>>(list);
        }
        public override Model.UserTrackVote Update(int id, UserTrackVoteUpsertRequest request)
        {
            var entity = _context.UserTrackVote.Where(a => a.TrackId == request.TrackId && a.UserId == request.UserId).FirstOrDefault();
            if ((entity.Liked == true && request.Liked == false) || (entity.Liked == false && request.Liked == true))
            {
                _context.Set<Database.UserTrackVote>().Attach(entity);
                _mapper.Map(request, entity);
            }
            else
            {
                _context.UserTrackVote.Remove(entity);
            }
            _context.SaveChanges();
            return _mapper.Map<Model.UserTrackVote>(entity);
        }
    }
}
