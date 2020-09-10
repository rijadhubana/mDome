using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class PostService : BaseCRUDService<Model.Post, PostSearchRequest, Database.Post, PostUpsertRequest, PostUpsertRequest>
    {
        public PostService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Post> Get(PostSearchRequest search)
        {
            var query = _context.Post.AsQueryable();
            if (search.ArtistRelatedId.HasValue)
            {
                query = query.Where(a => a.ArtistRelatedId == search.ArtistRelatedId);
            }
            if (search.IsGlobal.HasValue)
            {
                query = query.Where(a => a.IsGlobal == search.IsGlobal);
            }
            if (search.UserRelatedId.HasValue)
            {
                query = query.Where(a => a.UserRelatedId == search.UserRelatedId);
            }
            if (search.ReviewRelatedId.HasValue)
            {
                query = query.Where(a => a.ReviewRelatedId == search.ReviewRelatedId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Post>>(list);
        }
        public override Model.Post Delete(int Id)
        {
            _context.UserCommentPost.RemoveRange(_context.UserCommentPost.Where(a => a.PostId == Id));
            _context.SaveChanges();
            _context.UserLikePost.RemoveRange(_context.UserLikePost.Where(a => a.PostId == Id));
            _context.SaveChanges();
            var entity = _context.Post.Find(Id);
            var x = entity;
            if (entity.ReviewRelatedId.HasValue)
            {
                _context.Review.Remove(_context.Review.Find(entity.ReviewRelatedId));
                _context.SaveChanges();
            }
            _context.Post.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Post>(x);
        }
    }
}
