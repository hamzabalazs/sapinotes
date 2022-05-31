#nullable disable
using Microsoft.AspNetCore.Mvc;
using SapinotesAPI.Data.Models;
using SapinotesAPI.Services;
using SapinotesAPI.Repositories;
using SapinotesAPI.Data.Requests;
using SapinotesAPI.Data.Responses;
using SapinotesAPI.Exceptions;
using SapinotesAPI.Utils;

namespace SapinotesAPI.Controllers
{
    [Route("sapinotesapi/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UsersController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost, Route("add-new-user")]
        public async Task<ActionResult<User>> PostUser([FromBody] UserRequest user)
        {
            try
            {
                UserResponse result = await _userService.AddNewUser(user);
                return Ok(result);
            }
            catch (AddException ex)
            {
                UserResponse errorResponse = new UserResponse()
                {
                    Code = 400,
                    Message = APIErrorCodes.ADD_REQUEST_EXCEPTION_MESSAGE + ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpGet, Route("get-user-by-userId")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            try
            {
                var result = await _userRepository.GetUserById(userId);

                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete, Route("delete-user-by-id")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _userRepository.GetUserById(id);

                if (userToDelete == null)
                {
                    return NotFound();
                }

                await _userRepository.DeleteUserById(id);
                return Ok();


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting user");
            }

        }
    }
}
