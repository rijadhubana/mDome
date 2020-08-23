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
    }
}
