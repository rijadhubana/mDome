using AutoMapper;
using mDome.API.Database;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class ArtistGenreService : BaseCRUDService<Model.ArtistGenre,ArtistGenreSearchRequest,Database.ArtistGenre,ArtistGenreUpsertRequest,ArtistGenreUpsertRequest>
    {
        public ArtistGenreService(mDomeT1Context context, IMapper mapper) : base(context,mapper)
        {

        }
        public override List<Model.ArtistGenre> Get(ArtistGenreSearchRequest search)
        {
            var query = _context.ArtistGenre.AsQueryable();
            if (search.ArtistId.HasValue)
                query = query.Where(a => a.ArtistId == search.ArtistId);
            if (search.GenreId.HasValue)
                query = query.Where(a => a.GenreId == search.GenreId);
            var list = query.ToList();
            return _mapper.Map<List<Model.ArtistGenre>>(list);
        }
    }
}
