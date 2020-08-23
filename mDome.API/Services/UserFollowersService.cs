using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class UserFollowersService : BaseCRUDService<Model.UserFollowers, UserFollowersSearchRequest, Database.UserFollowers, UserFollowersUpsertRequest, UserFollowersUpsertRequest>
    {
        public UserFollowersService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.UserFollowers> Get(UserFollowersSearchRequest search)
        {
            var query = _context.UserFollowers.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x=>x.UserId==search.UserId);
            }
            if (search.FollowedByUserId.HasValue)
            {
                query = query.Where(x => x.FollowedByUserId == search.FollowedByUserId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.UserFollowers>>(list);
        }
        public override Model.UserFollowers Update(int id, UserFollowersUpsertRequest request)
        {
            var entity = _context.UserFollowers.Where(a => a.UserId == request.UserId && a.FollowedByUserId == request.FollowedByUserId).FirstOrDefault();
            _context.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.UserFollowers>(entity);
        }
    }
}
