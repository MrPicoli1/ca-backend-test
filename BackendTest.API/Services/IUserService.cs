using BackendTest.API.Domain.Entities;
using BackendTest.API.Models;

namespace BackendTest.API.Services
{
    public interface IUserService
    {
        public Task<User> AddUser(UserModel model);
        public Task<User> GetUser(Guid id);
        public Task<User> UpdateUser(UserModel model, Guid? id);
        public Task<bool> DeleteUSer(Guid id);
    }
}
