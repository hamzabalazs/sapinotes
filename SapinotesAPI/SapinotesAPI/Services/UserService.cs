using SapinotesAPI.Data.Models;
using SapinotesAPI.Data.Responses;
using SapinotesAPI.Data.Requests;
using SapinotesAPI.Exceptions;
using SapinotesAPI.Repositories;
using SapinotesAPI.Utils;
using System.ComponentModel;

namespace SapinotesAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> AddNewUser(UserRequest newUser)
        {
            User user = new User()
            {
                username = newUser.username,
                email = newUser.email,
                password = newUser.password,
            };

            UserResponse response = new UserResponse();

            try
            {
                response.User = await _userRepository.AddNewUser(user);
                if(response.User != null)
                {
                    response.Message = "Successful!";
                    response.Code = 200;
                }
                return response;
            }
            catch (AddRequestException ex)
            {
                throw new AddException(ex.Message);
            }


        }
    }
}
