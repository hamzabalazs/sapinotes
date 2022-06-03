using SapinotesAPI.Data;
using SapinotesAPI.Data.Models;
using SapinotesAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace SapinotesAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddNewUser(User newUser)
        {
            try
            {
                var addresponse = _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return addresponse.Entity;
            }
            catch (Exception ex)
            {
                throw new AddRequestException(ex.Message);
            }
        }

        public async Task DeleteUserById(int userId)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.userID == userId);

            if (result != null)
            {
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.userID == userId);
        }

        public async Task<User> LoginUser(string userEmail,string userPassword)
        {
            try
            {
                return await _context.Users.Where(u => u.email == userEmail && u.password == userPassword).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new GetRequestException(ex.Message);
            }
        }
    }
}
