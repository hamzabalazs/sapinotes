using SapinotesAPI.Data.Requests;
using SapinotesAPI.Data.Responses;

namespace SapinotesAPI.Services
{
    public interface IUserService
    {
        public Task<UserResponse> AddNewUser(UserRequest newUser);
    }
}
