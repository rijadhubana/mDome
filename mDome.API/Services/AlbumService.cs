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
        public override Model.Album Delete(int Id)
        {
            var entity = _context.Album.Find(Id);
            _context.AlbumListAlbum.RemoveRange(_context.AlbumListAlbum.Where(a => a.AlbumId == entity.AlbumId));
            _context.SaveChanges();
            _context.Review.RemoveRange(_context.Review.Where(a => a.AlbumId == entity.AlbumId));
            _context.SaveChanges();
            List<Track> list = _context.Track.Where(a => a.AlbumId == entity.AlbumId).ToList();
            foreach (var item in list)
            {
                var entityTr = item;
                _context.TracklistTrack.RemoveRange(_context.TracklistTrack.Where(a => a.TrackId == item.TrackId));
                _context.UserTrackVote.RemoveRange(_context.UserTrackVote.Where(a => a.TrackId == item.TrackId));
                _context.Track.Remove(entityTr);
            }
            _context.SaveChanges();
            var x = entity;
            _context.Album.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Album>(x);
        }
    }
}
