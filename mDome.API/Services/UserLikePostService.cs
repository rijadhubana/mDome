using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class UserLikePostService : BaseCRUDService<Model.UserLikePost, UserLikePostSearchRequest, Database.UserLikePost, UserLikePostUpsertRequest, UserLikePostUpsertRequest>
    {
        public UserLikePostService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.UserLikePost> Get(UserLikePostSearchRequest search)
        {
            var query = _context.UserLikePost.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (search.PostId.HasValue)
            {
                query = query.Where(x => x.PostId == search.PostId);
            }
            if (search.Liked.HasValue)
            {
                query = query.Where(x => x.Liked == search.Liked);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.UserLikePost>>(list);
        }
        public override Model.UserLikePost Update(int id, UserLikePostUpsertRequest request)
        {
            var entity = _context.UserLikePost.Where(a => a.PostId == request.PostId && a.UserId == request.UserId).FirstOrDefault();
            if ((entity.Liked==true && request.Liked==false) || (entity.Liked==false && request.Liked==true))
            {
                _context.Set<Database.UserLikePost>().Attach(entity);
                _mapper.Map(request, entity);
            }
            else
            {
                _context.UserLikePost.Remove(entity);
            }
            _context.SaveChanges();
            return _mapper.Map<Model.UserLikePost>(entity);
        }
    }
}
