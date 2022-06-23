using Microsoft.EntityFrameworkCore;
using SapinotesAPI.Data;
using SapinotesAPI.Data.Models;
using SapinotesAPI.Exceptions;

namespace SapinotesAPI.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;
        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rating> AddNewRating(Rating newRating)
        {
            try
            {
                var addresponse = _context.Ratings.Add(newRating);
                await _context.SaveChangesAsync();

                return addresponse.Entity;
            }
            catch (Exception ex)
            {
                throw new AddRequestException(ex.Message);
            }
        }

        public async Task<IEnumerable<Rating>> GetAllRatingsOfNote(int noteId)
        {
            try
            {
                return await _context.Ratings.Where(r => r.noteID == noteId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new GetRequestException(ex.Message);
            }
        }

        public async Task<Rating> GetRatingById(int ratingId)
        {
            return await _context.Ratings.FirstOrDefaultAsync(r => r.ratingID == ratingId);
        }

        public async Task DeleteRatingById(int ratingId)
        {
            var result = await _context.Ratings.FirstOrDefaultAsync(r => r.ratingID == ratingId);

            if (result != null)
            {
                _context.Ratings.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rating>> GetRatingsOfUserForNote(int userId,int noteId)
        {
            try
            {
                return await _context.Ratings.Where(r => r.noteID == noteId && r.userID == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new GetRequestException(ex.Message);
            }
        }
    }
}
