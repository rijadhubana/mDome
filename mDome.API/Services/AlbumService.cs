using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class AlbumService : BaseCRUDService<Model.Album, AlbumSearchRequest, Database.Album, AlbumUpsertRequest, AlbumUpsertRequest>
    {
        public AlbumService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Album> Get(AlbumSearchRequest search)
        {
            var query = _context.Album.AsQueryable();
            if (search.ArtistId.HasValue)
            {
                query = query.Where(a => a.ArtistId == search.ArtistId);
            }
            if (!string.IsNullOrWhiteSpace(search?.AlbumName))
            {
                query = query.Where(x => x.AlbumName.ToLower().Contains(search.AlbumName.ToLower()));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Album>>(list);
        }
        public override Model.Album Delete(int albumId)
        {
            //deleting everything related to selected album 1.likes
            _context.UserAlbumVote.RemoveRange(_context.UserAlbumVote.Where(a => a.AlbumId == albumId));
            _context.SaveChanges();
            //review related (postlike,postcomments,post,reviews)
            var listReviews = _context.Review.Where(a => a.AlbumId == albumId).ToList();
            foreach (var item in listReviews)
            {
                //only one post is related to a single review
                var post = _context.Post.Where(a => a.ReviewRelatedId == item.ReviewId).FirstOrDefault();
                _context.UserLikePost.RemoveRange(_context.UserLikePost.Where(a => a.PostId == post.PostId));
                _context.UserCommentPost.RemoveRange(_context.UserCommentPost.Where(a => a.PostId == post.PostId));
                _context.SaveChanges();
                _context.Remove(post);
                _context.Remove(item);
                _context.SaveChanges();
            }
            //deleting album from albumlists
            _context.AlbumListAlbum.RemoveRange(_context.AlbumListAlbum.Where(a => a.AlbumId == albumId));
            _context.SaveChanges();
            //tracks and tracklistTracks, set recommendedalbums to null 
            var tracks = _context.Track.Where(a => a.AlbumId == albumId).ToList();
            foreach (var item in tracks)
            {
                _context.UserTrackVote.RemoveRange(_context.UserTrackVote.Where(a => a.TrackId == item.TrackId));
                _context.TracklistTrack.RemoveRange(_context.TracklistTrack.Where(a => a.TrackId == item.TrackId));
                _context.Track.Remove(item);
            }
            _context.SaveChanges();
            var listUsers = _context.UserProfile.Where(a => a.RecommendedAlbum1 == albumId);
            foreach (var item in listUsers)
                item.RecommendedAlbum1 = null;
            _context.SaveChanges();
            listUsers = _context.UserProfile.Where(a => a.RecommendedAlbum2 == albumId);
            foreach (var item in listUsers)
                item.RecommendedAlbum2 = null;
            _context.SaveChanges();
            listUsers = _context.UserProfile.Where(a => a.RecommendedAlbum3 == albumId);
            foreach (var item in listUsers)
                item.RecommendedAlbum3 = null;
            _context.SaveChanges();
            var entity = _context.Album.Find(albumId);
            _context.Album.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Album>(entity);
        }
    }
}
