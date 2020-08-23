using AutoMapper;
using mDome.API.Database;
using mDome.API.Helper;
using mDome.Model.Requests;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Services
{
    public class UserProfileService : BaseCRUDService<Model.UserProfile, UserProfileSearchRequest, Database.UserProfile, UserProfileUpsertRequest, UserProfileUpsertRequest>
    {
        public UserProfileService(mDomeT1Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.UserProfile> Get(UserProfileSearchRequest search)
        {
            var query = _context.UserProfile.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                query = query.Where(x => x.Username == search.Username);
            }
            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                query = query.Where(x => x.Email == search.Email);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.UserProfile>>(list);
        }
        internal Model.UserProfile Authenticate(string username, string password)
        {
            var user = _context.UserProfile.Where(x => x.Username == username).FirstOrDefault();
            if (user != null)
            {
                var newHash = Methods.GenerateHash(user.PasswordSalt, password);
                if (newHash == user.PasswordHash)
                    return _mapper.Map<Model.UserProfile>(user);
            }
            return null;
        }
        public override Model.UserProfile Insert(UserProfileUpsertRequest request)
        {
            var entity = _mapper.Map<Database.UserProfile>(request);
            if (request.PasswordClearText != request.PasswordClearTextConfirm)
            {
                throw new Exception("Passwords do not match!");
            }
            if (_context.AdministratorLogin.Where(a => a.AdminName == request.Username).FirstOrDefault() != null 
                || _context.UserProfile.Where(a=>a.Username==request.Username).FirstOrDefault() !=null
                || _context.UserProfile.Where(a=>a.Email==request.Email).FirstOrDefault()!=null)
            {
                throw new Exception("A user with the same name or email already exists!");
            }
            entity.PasswordSalt = Helper.Methods.GenerateSalt();
            entity.PasswordHash = Helper.Methods.GenerateHash(entity.PasswordSalt, request.PasswordClearText);
            _context.UserProfile.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.UserProfile>(entity);
        }
        public override Model.UserProfile Update(int id, UserProfileUpsertRequest request)
        {
            var entity = _context.UserProfile.Find(id);
            if (request.PasswordClearText != request.PasswordClearTextConfirm)
            {
                throw new Exception("Passwords do not match!");
            }
            _context.Set<Database.UserProfile>().Attach(entity);
            _mapper.Map(request, entity);
            entity.PasswordSalt = Helper.Methods.GenerateSalt();
            entity.PasswordHash = Helper.Methods.GenerateHash(entity.PasswordSalt, request.PasswordClearText);
            _context.SaveChanges();
            return _mapper.Map<Model.UserProfile>(entity);

        }
    }
}
