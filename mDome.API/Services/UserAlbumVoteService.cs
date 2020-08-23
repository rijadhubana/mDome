using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class UserAlbumVoteService : BaseCRUDService<Model.UserAlbumVote, UserAlbumVoteSearchRequest, Database.UserAlbumVote, UserAlbumVoteUpsertRequest, UserAlbumVoteUpsertRequest>
    {
        public UserAlbumVoteService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.UserAlbumVote> Get(UserAlbumVoteSearchRequest search)
        {
            var query = _context.UserAlbumVote.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (search.AlbumId.HasValue)
            {
                query = query.Where(x => x.AlbumId == search.AlbumId);
            }
            if (search.Liked.HasValue)
            {
                query = query.Where(x => x.Liked == search.Liked);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.UserAlbumVote>>(list);
        }
        public override Model.UserAlbumVote Update(int id, UserAlbumVoteUpsertRequest request)
        {
            var entity = _context.UserAlbumVote.Where(a => a.AlbumId == request.AlbumId && a.UserId == request.UserId).FirstOrDefault();
            if ((entity.Liked == true && request.Liked == false) || (entity.Liked == false && request.Liked == true))
            {
                _context.Set<Database.UserAlbumVote>().Attach(entity);
                _mapper.Map(request, entity);
            }
            else
            {
                _context.UserAlbumVote.Remove(entity);
            }
            _context.SaveChanges();
            return _mapper.Map<Model.UserAlbumVote>(entity);
        }
    }
}
