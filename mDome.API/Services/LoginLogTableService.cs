using AutoMapper;
using mDome.API.Database;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class LoginLogTableService : BaseCRUDService<Model.LoginLogTable, LoginLogSearchRequest, Database.LoginLogTable, LoginLogUpsertRequest, LoginLogUpsertRequest>
    {
        public LoginLogTableService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.LoginLogTable> Get(LoginLogSearchRequest search)
        {
            var query = _context.LoginLogTable.AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId==search.UserId);
            }
            if (search.DateOfLogin.HasValue)
            {
                query = query.Where(x => x.DateOfLogin == search.DateOfLogin);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.LoginLogTable>>(list);
        }
    }
}
