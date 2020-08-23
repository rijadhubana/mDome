using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class UserCommentPostService : BaseCRUDService<Model.UserCommentPost, UserCommentPostSearchRequest, Database.UserCommentPost, UserCommentPostUpsertRequest, UserCommentPostUpsertRequest>
    {
        public UserCommentPostService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.UserCommentPost> Get(UserCommentPostSearchRequest search)
        {
            var query = _context.UserCommentPost.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (search.PostId.HasValue)
            {
                query = query.Where(x => x.PostId == search.PostId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.UserCommentPost>>(list);
        }
    }
}
