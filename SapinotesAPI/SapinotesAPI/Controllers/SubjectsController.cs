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
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository, ISubjectService subjectService)
        {
            _subjectRepository = subjectRepository;
            _subjectService = subjectService;
        }

        [HttpPost, Route("add-new-subject")]
        public async Task<ActionResult<Subject>> PostSubject([FromBody] SubjectRequest subject)
        {
            try
            {
                SubjectResponse result = await _subjectService.AddNewSubject(subject);
                return Ok(result);
            }
            catch (AddException ex)
            {
                SubjectResponse errorResponse = new SubjectResponse()
                {
                    Code = 400,
                    Message = APIErrorCodes.ADD_REQUEST_EXCEPTION_MESSAGE + ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpGet, Route("get-subject-by-subjectId")]
        public async Task<ActionResult<Subject>> GetSubjectById(int subjectId)
        {
            try
            {
                var result = await _subjectRepository.GetSubjectById(subjectId);

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

        [HttpDelete, Route("delete-subject-by-id")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            try
            {
                var subjectToDelete = await _subjectRepository.GetSubjectById(id);

                if (subjectToDelete == null)
                {
                    return NotFound();
                }

                await _subjectRepository.DeleteSubjectById(id);
                return Ok();


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting subject");
            }

        }
        [HttpGet, Route("get-subjects-of-major")]
        public async Task<ActionResult> GetSubjectsByMajor(int majorId)
        {
            try
            {
                return Ok(await _subjectRepository.GetSubjectsByMajorId(majorId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
