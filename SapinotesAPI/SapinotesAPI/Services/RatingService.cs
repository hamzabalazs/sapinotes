using SapinotesAPI.Data.Models;
using SapinotesAPI.Data.Requests;
using SapinotesAPI.Data.Responses;
using SapinotesAPI.Exceptions;
using SapinotesAPI.Repositories;

namespace SapinotesAPI.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<RatingResponse> AddNewRating(RatingRequest newRating)
        {
            Rating rating = new Rating()
            {
                
                noteID = newRating.noteID,
                userID = newRating.userID,
                ratingValue = newRating.ratingValue,
                
            };

            RatingResponse response = new RatingResponse();

            try
            {
                response.Rating = await _ratingRepository.AddNewRating(rating);
                if (response.Rating != null)
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
