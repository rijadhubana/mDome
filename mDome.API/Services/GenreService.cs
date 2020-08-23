using AutoMapper;
using mDome.API.Database;
using mDome.Model;
using mDome.Model.Requests;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class GenreService : BaseCRUDService<Model.Genre,GenreSearchRequest,Database.Genre,GenreUpsertRequest,GenreUpsertRequest>
    {
        public GenreService(mDomeT1Context context, IMapper mapper):base(context,mapper)
        {

        }
        public override List<Model.Genre> Get(GenreSearchRequest search)
        {
            var query = _context.Genre.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.GenreName))
            {
                query = query.Where(x => x.GenreName.StartsWith(search.GenreName));
            }
            query = query.OrderBy(x => x.GenreName);
            var list = query.ToList();
            return _mapper.Map<List<Model.Genre>>(list);
        }
    }
}
