using AutoMapper;
using Flurl.Http;
using mDome.API.Database;
using mDome.Model.Requests;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class TracklistService : BaseCRUDService<Model.Tracklist, TracklistSearchRequest, Database.Tracklist, TracklistUpsertRequest, TracklistUpsertRequest>
    {
        public TracklistService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Tracklist> Get(TracklistSearchRequest search)
        {
            var query = _context.Tracklist.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (!string.IsNullOrWhiteSpace(search.TracklistName))
            {
                query = query.Where(x => x.TracklistName.Contains(search.TracklistName));
            }
            if (!string.IsNullOrWhiteSpace(search.TracklistType))
            {
                query = query.Where(x => x.TracklistType == search.TracklistType);
            }
            if (!string.IsNullOrWhiteSpace(search.UniqueKey))
            {
                query = query.Where(x => x.UniqueKey == search.UniqueKey);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Tracklist>>(list);
        }
        public override Model.Tracklist Delete(int Id)
        {
            var entity = _context.Tracklist.Find(Id);
            _context.TracklistTrack.RemoveRange(_context.TracklistTrack.Where(a => a.TracklistId == entity.TracklistId));
            _context.SaveChanges();
            _context.Tracklist.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Tracklist>(entity);
        }
        public override Model.Tracklist Insert(TracklistUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Tracklist>(request);
            if (_context.Tracklist.Where(a=>a.TracklistName == request.TracklistName && a.UniqueKey==request.UniqueKey).FirstOrDefault() != null)
            {
                throw new Exception("Please change the tracklist name or unique key!");
            }
            _context.Tracklist.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Tracklist>(entity);
        }
        public override Model.Tracklist Update(int id, TracklistUpsertRequest request)
        {
            var entity = _context.Tracklist.Find(id);
            if (_context.Tracklist.Where(a => a.TracklistName == request.TracklistName && a.UniqueKey == request.UniqueKey
            && a.TracklistId != id).FirstOrDefault() != null)
                throw new Exception("Please change the unique key or tracklist name.");
            _context.Set<Database.Tracklist>().Attach(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Tracklist>(entity);
        }
    }
}
