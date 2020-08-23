using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class AlbumListService : BaseCRUDService<Model.AlbumList, AlbumListSearchRequest, Database.AlbumList, AlbumListUpsertRequest, AlbumListUpsertRequest>
    {
        public AlbumListService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.AlbumList> Get(AlbumListSearchRequest search)
        {
            var query = _context.AlbumList.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (!string.IsNullOrWhiteSpace(search.AlbumListName))
            {
                query = query.Where(x=>x.AlbumListName.Contains(search.AlbumListName));
            }
            if (!string.IsNullOrWhiteSpace(search.AlbumListType))
            {
                query = query.Where(x => x.AlbumListType==search.AlbumListType);
            }
            if (!string.IsNullOrWhiteSpace(search.UniqueKey))
            {
                query = query.Where(x => x.UniqueKey == search.UniqueKey);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.AlbumList>>(list);
        }
        public override Model.AlbumList Insert(AlbumListUpsertRequest request)
        {
            var entity = _mapper.Map<Database.AlbumList>(request);
            if (_context.AlbumList.Where(a => a.AlbumListName == request.AlbumListName && a.UniqueKey == request.UniqueKey).FirstOrDefault() != null)
            {
                throw new Exception("Please change the unique key or tracklist name.");
            }
            _context.AlbumList.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.AlbumList>(entity);
        }
        public override Model.AlbumList Update(int id, AlbumListUpsertRequest request)
        {
            var entity = _context.AlbumList.Find(id);
            if (_context.AlbumList.Where(a => a.AlbumListName == request.AlbumListName && a.UniqueKey == request.UniqueKey
            && a.AlbumListId != id).FirstOrDefault() != null)
                throw new Exception("Please change the unique key or tracklist name.");
            _context.Set<Database.AlbumList>().Attach(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.AlbumList>(entity);
        }
        public override Model.AlbumList Delete(int Id)
        {
            var entity = _context.AlbumList.Find(Id);
            _context.AlbumListAlbum.RemoveRange(_context.AlbumListAlbum.Where(a => a.AlbumListId == entity.AlbumListId));
            _context.SaveChanges();
            _context.AlbumList.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.AlbumList>(entity);
        }
    }
}
