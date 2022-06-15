using SapinotesAPI.Data.Requests;
using SapinotesAPI.Data.Responses;

namespace SapinotesAPI.Services
{
    public interface IRatingService
    {
        public Task<RatingResponse> AddNewRating(RatingRequest newRating);
    }
}
