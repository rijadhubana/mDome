using AutoMapper;
using mDome.API.Database;
using mDome.API.Helper;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class AdministratorLoginService : BaseCRUDService<Model.AdministratorLogin, AdminSearchRequest, Database.AdministratorLogin, AdminUpsertRequest, AdminUpsertRequest>
    {
        public AdministratorLoginService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.AdministratorLogin> Get(AdminSearchRequest search)
        {
            var query = _context.AdministratorLogin.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.AdminName))
            {
                query = query.Where(x => x.AdminName == search.AdminName);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.AdministratorLogin>>(list);
        }

        internal Model.AdministratorLogin Authenticate(string username, string password)
        {
            var user = _context.AdministratorLogin.Where(x => x.AdminName == username).FirstOrDefault();
            if (user != null)
            {
                var newHash = Methods.GenerateHash(user.PasswordSalt, password);
                if (newHash == user.PasswordHash)
                    return _mapper.Map<Model.AdministratorLogin>(user);
            }
            return null;
        }
        public override Model.AdministratorLogin Insert(AdminUpsertRequest request)
        {
            var entity = _mapper.Map<Database.AdministratorLogin>(request);
            if (request.PasswordClear != request.PasswordClearConfirm)
            {
                throw new Exception("Passwords do not match!");
            }
            if (_context.AdministratorLogin.Where(a=>a.AdminName==request.AdminName).FirstOrDefault()!=null)
            {
                throw new Exception("An administrator with the same name already exists!");
            }
            entity.PasswordSalt = Helper.Methods.GenerateSalt();
            entity.PasswordHash = Helper.Methods.GenerateHash(entity.PasswordSalt, request.PasswordClear);
            _context.AdministratorLogin.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.AdministratorLogin>(entity);
        }
        public override Model.AdministratorLogin Update(int id, AdminUpsertRequest request)
        {
            var entity = _context.AdministratorLogin.Find(id);
            _mapper.Map(request, entity);
            if (request.PasswordClear != request.PasswordClearConfirm)
            {
                throw new Exception("Passwords do not match!");
            }
            if (_context.AdministratorLogin.Where(a => a.AdminName == request.AdminName).FirstOrDefault() != null)
            {
                throw new Exception("An administrator with the same name already exists!");
            }
            entity.PasswordSalt = Helper.Methods.GenerateSalt();
            entity.PasswordHash = Helper.Methods.GenerateHash(entity.PasswordSalt, request.PasswordClear);
            entity.AdminName = request.AdminName;
            _context.SaveChanges();
            return _mapper.Map<Model.AdministratorLogin>(entity);
        }
    }
}
