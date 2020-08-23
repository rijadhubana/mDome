using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class UserFollowsArtistService : BaseCRUDService<Model.UserFollowsArtist, UserFollowsArtistSearchRequest, Database.UserFollowsArtist, UserFollowsArtistUpsertRequest, UserFollowsArtistUpsertRequest>
    {
        public UserFollowsArtistService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.UserFollowsArtist> Get(UserFollowsArtistSearchRequest search)
        {
            var query = _context.UserFollowsArtist.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (search.ArtistId.HasValue)
            {
                query = query.Where(x => x.ArtistId == search.ArtistId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.UserFollowsArtist>>(list);
        }
        public override Model.UserFollowsArtist Update(int id, UserFollowsArtistUpsertRequest request)
        {
            var entity = _context.UserFollowsArtist.Where(a => a.UserId == request.UserId && a.ArtistId == request.ArtistId).FirstOrDefault();
            _context.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.UserFollowsArtist>(entity);
        }
    }
}
