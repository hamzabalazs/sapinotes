#nullable disable
using Microsoft.AspNetCore.Mvc;
using SapinotesAPI.Data.Models;
using SapinotesAPI.Services;
using SapinotesAPI.Repositories;
using SapinotesAPI.Data.Requests;
using SapinotesAPI.Data.Responses;
using SapinotesAPI.Exceptions;
using SapinotesAPI.Utils;
using SapinotesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SapinotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly IMajorRepository _majorRepository;
        private readonly IMajorService _majorService;
        private readonly AppDbContext _context;

        public MajorsController(IMajorService majorService, IMajorRepository majorRepository,AppDbContext context )
        {
            _majorRepository = majorRepository;
            _majorService = majorService;
            _context = context;
        }

        [HttpPost, Route("add-new-major")]
        public async Task<ActionResult<Major>> PostMajor([FromBody] MajorRequest major)
        {
            try
            {
                MajorResponse result = await _majorService.AddNewMajor(major);
                return Ok(result);
            }
            catch (AddException ex)
            {
                MajorResponse errorResponse = new MajorResponse()
                {
                    Code = 400,
                    Message = APIErrorCodes.ADD_REQUEST_EXCEPTION_MESSAGE + ex.Message
                };
                return BadRequest(errorResponse);
            }
        }
        [HttpGet, Route("get-major-by-majorId")]
        public async Task<ActionResult<Major>> GetMajorById(int majorId)
        {
            try
            {
                var result = await _majorRepository.GetMajorById(majorId);

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

        [HttpDelete, Route("delete-major-by-id")]
        public async Task<ActionResult> DeleteMajor(int id)
        {
            try
            {
                var majorToDelete = await _majorRepository.GetMajorById(id);

                if (majorToDelete == null)
                {
                    return NotFound();
                }

                await _majorRepository.DeleteMajorById(id);
                return Ok();


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting major");
            }

        }

        [HttpGet,Route("getmajors")]
        public async Task<IEnumerable<Major>> GetAllMajors()
        {
            return await _context.Majors.ToListAsync();
        }


    }
}
