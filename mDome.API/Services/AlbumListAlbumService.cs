using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class AlbumListAlbumService : BaseCRUDService<Model.AlbumListAlbum, AlbumListAlbumSearchRequest, Database.AlbumListAlbum, AlbumListAlbumUpsertRequest, AlbumListAlbumUpsertRequest>
    {
        public AlbumListAlbumService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.AlbumListAlbum> Get(AlbumListAlbumSearchRequest search)
        {
            var query = _context.AlbumListAlbum.AsQueryable();
            if (search.AlbumId.HasValue)
            {
                query = query.Where(x => x.AlbumId == search.AlbumId);
            }
            if (search.AlbumListId.HasValue)
            {
                query = query.Where(x => x.AlbumListId == search.AlbumListId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.AlbumListAlbum>>(list);
        }
        public override Model.AlbumListAlbum Update(int id, AlbumListAlbumUpsertRequest request)
        {
            var entity = _context.AlbumListAlbum.Where(a => a.AlbumId == request.AlbumId && a.AlbumListId == request.AlbumListId).FirstOrDefault();
            _context.AlbumListAlbum.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.AlbumListAlbum>(entity);
        }
    }
}
