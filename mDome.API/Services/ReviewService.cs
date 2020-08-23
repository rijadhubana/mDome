using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class ReviewService : BaseCRUDService<Model.Review, ReviewSearchRequest, Database.Review, ReviewUpsertRequest, ReviewUpsertRequest>
    {
        public ReviewService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Review> Get(ReviewSearchRequest search)
        {
            var query = _context.Review.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(a => a.UserId == search.UserId);
            }
            if (search.AlbumId.HasValue)
            {
                query = query.Where(a => a.AlbumId == search.AlbumId);
            }
            if (search.RatingFrom.HasValue && search.RatingTo.HasValue)
            {
                query = query.Where(a => a.Rating >= search.RatingFrom && a.Rating <= search.RatingTo);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Review>>(list);
        }
        public override Model.Review Delete(int Id)
        {
            int postId = _context.Post.Where(a => a.ReviewRelatedId == Id).Select(a => a.PostId).FirstOrDefault();
            _context.UserCommentPost.RemoveRange(_context.UserCommentPost.Where(a => a.PostId == postId));
            _context.SaveChanges();
            _context.UserLikePost.RemoveRange(_context.UserLikePost.Where(a => a.PostId == postId));
            _context.SaveChanges();
            _context.Post.Remove(_context.Post.Find(postId));
            _context.SaveChanges();
            var entity = _context.Review.Find(Id);
            var x = entity;
            _context.Review.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Review>(x);
        }
    }
}
