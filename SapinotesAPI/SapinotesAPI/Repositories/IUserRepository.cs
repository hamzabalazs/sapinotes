using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Repositories
{
    public interface IUserRepository
    {
        public Task<User> AddNewUser(User newUser);
        public Task<User> GetUserById(int userId);
        public Task<User> LoginUser(string userEmail, string userPassword);
        public Task DeleteUserById(int userId);
    }
}
