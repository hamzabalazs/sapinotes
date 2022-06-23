using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Repositories
{
    public interface IRatingRepository
    {
        public Task<Rating> AddNewRating(Rating rating);
        public Task<IEnumerable<Rating>> GetAllRatingsOfNote(int noteId);
        public Task DeleteRatingById(int ratingId);
        public Task<Rating> GetRatingById(int ratingId);
        public Task<IEnumerable<Rating>> GetRatingsOfUserForNote(int userId, int noteId);
    }
}
