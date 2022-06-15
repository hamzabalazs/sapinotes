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
    public class RatingsController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingRepository ratingRepository, IRatingService ratingService)
        {
            _ratingRepository = ratingRepository;
            _ratingService = ratingService;
        }

        [HttpPost, Route("add-new-rating")]
        public async Task<ActionResult<Rating>> PostRating([FromBody] RatingRequest rating)
        {
            try
            {
                RatingResponse result = await _ratingService.AddNewRating(rating);
                return Ok(result);
            }
            catch (AddException ex)
            {
                RatingResponse errorResponse = new RatingResponse()
                {
                    Code = 400,
                    Message = APIErrorCodes.ADD_REQUEST_EXCEPTION_MESSAGE + ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpGet, Route("get-ratings-of-note")]
        public async Task<ActionResult> GetRatingsByNote(int noteId)
        {
            try
            {
                return Ok(await _ratingRepository.GetAllRatingsOfNote(noteId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete, Route("delete-rating-by-id")]
        public async Task<ActionResult> DeleteRating(int id)
        {
            try
            {
                var ratingToDelete = await _ratingRepository.GetRatingById(id);

                if (ratingToDelete == null)
                {
                    return NotFound();
                }

                await _ratingRepository.DeleteRatingById(id);
                return Ok();


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting rating");
            }

        }
    }
}
