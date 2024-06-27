using AutoMapper;
using BackendTest.API.Data.Repositories;
using BackendTest.API.Domain.Entities;
using BackendTest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.API.Services
{
    public class UserService : IUserService
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public UserService(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> AddUser(UserModel model)
        {

            if(model.IsNull())
                return null;

            var user = _mapper.Map<User>(model);

            if(user.IsValid().Count()>0)
            {
                return user;
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

            
        }

        public async Task<bool> DeleteUSer(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null) 
            {
                return false;
            }

            _context.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            return user;

        }

        public async Task<User> UpdateUser(UserModel model, Guid? id)
        {

            if (id == null || model.IsNull())
                return null;

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            user.Update(model.Name, model.Email, model.Address);

            if (user.IsValid().Count()>0)
            {
                return user;
            }

            _context.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
