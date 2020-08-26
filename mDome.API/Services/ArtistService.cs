using AutoMapper;
using mDome.API.Database;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class ArtistService : BaseCRUDService<Model.Artist, ArtistSearchRequest, Database.Artist, ArtistUpsertRequest, ArtistUpsertRequest>
    {
        public ArtistService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Artist> Get(ArtistSearchRequest search)
        {
            var query = _context.Artist.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.ArtistName))
            {
                query = query.Where(x => x.ArtistName.StartsWith(search.ArtistName));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Artist>>(list);
        }
        public override Model.Artist Insert(ArtistUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Artist>(request);
            _context.Artist.Add(entity);
            _context.SaveChanges();
            foreach (var item in request.Genres)
            {
                _context.ArtistGenre.Add(new Database.ArtistGenre()
                {
                    ArtistId=entity.ArtistId,
                    GenreId=item
                });
            }
            _context.SaveChanges();
            return _mapper.Map<Model.Artist>(entity);
        }
        public override Model.Artist Update(int id, ArtistUpsertRequest request)
        {
            var entity = _context.Artist.Find(id);
            _context.Set<Database.Artist>().Attach(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            _context.ArtistGenre.RemoveRange(_context.ArtistGenre.Where(a => a.ArtistId == entity.ArtistId));
            _context.SaveChanges();
            foreach (var item in request.Genres)
            {
                _context.ArtistGenre.Add(new Database.ArtistGenre()
                {
                    ArtistId = entity.ArtistId,
                    GenreId = item
                });
            }
            _context.SaveChanges();
            return _mapper.Map<Model.Artist>(entity);
        }
        public override Model.Artist Delete(int artistId)
        {
            var albumList = _context.Album.Where(a => a.ArtistId == artistId).ToList();
            foreach (var x in albumList)
            {
                int albumId = x.AlbumId;
                //deleting everything related to selected album 1.likes
                _context.UserAlbumVote.RemoveRange(_context.UserAlbumVote.Where(a => a.AlbumId == albumId));
                _context.SaveChanges();
                //review related (postlike,postcomments,post,reviews)
                var listReviews = _context.Review.Where(a => a.AlbumId == albumId);
                foreach (var item in listReviews)
                {
                    //only one post is related to a single review
                    var post = _context.Post.Where(a => a.ReviewRelatedId == item.ReviewId).FirstOrDefault();
                    _context.UserLikePost.RemoveRange(_context.UserLikePost.Where(a => a.PostId == post.PostId));
                    _context.UserCommentPost.RemoveRange(_context.UserCommentPost.Where(a => a.PostId == post.PostId));
                    _context.SaveChanges();
                    _context.Remove(post);
                    _context.Remove(item);
                    //_context.SaveChanges();
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
                _context.Album.Remove(x);
                _context.SaveChanges();
            }
            //deleting all artist related posts 
            var listPosts = _context.Post.Where(a => a.ArtistRelatedId == artistId);
            foreach (var item in listPosts)
            {
                _context.UserLikePost.RemoveRange(_context.UserLikePost.Where(a => a.PostId == item.PostId));
                _context.UserCommentPost.RemoveRange(_context.UserCommentPost.Where(a => a.PostId == item.PostId));
                _context.SaveChanges();
                _context.Remove(item);
                _context.SaveChanges();
            }
            //deleting all ArtistGenres, ArtistFollows
            _context.ArtistGenre.RemoveRange(_context.ArtistGenre.Where(a => a.ArtistId == artistId));
            _context.UserFollowsArtist.RemoveRange(_context.UserFollowsArtist.Where(a => a.ArtistId == artistId));
            _context.SaveChanges();
            var listUsersA = _context.UserProfile.Where(a => a.RecommendedArtist1 == artistId);
            foreach (var item in listUsersA)
                item.RecommendedArtist1 = null;
            _context.SaveChanges();
            listUsersA = _context.UserProfile.Where(a => a.RecommendedArtist2 == artistId);
            foreach (var item in listUsersA)
                item.RecommendedArtist2 = null;
            _context.SaveChanges();
            listUsersA = _context.UserProfile.Where(a => a.RecommendedArtist3 == artistId);
            foreach (var item in listUsersA)
                item.RecommendedArtist3 = null;
            _context.SaveChanges();
            var entity = _context.Artist.Find(artistId);
            _context.Artist.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Artist>(entity);
        }
    }
}
