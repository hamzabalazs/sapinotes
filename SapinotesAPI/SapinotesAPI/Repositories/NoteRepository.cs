using Microsoft.EntityFrameworkCore;
using SapinotesAPI.Data;
using SapinotesAPI.Data.Models;
using SapinotesAPI.Exceptions;

namespace SapinotesAPI.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;
        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Note> AddNewNote(Note newNote)
        {
            try
            {
                var addresponse = _context.Notes.Add(newNote);
                await _context.SaveChangesAsync();

                return addresponse.Entity;
            }
            catch (Exception ex)
            {
                throw new AddRequestException(ex.Message);
            }
        }

        public async Task<IEnumerable<Note>> GetAllNotesOfUser(int userId)
        {
            try
            {
                return await _context.Notes.Where(n => n.userID == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new GetRequestException(ex.Message);
            }
        }

        public async Task<IEnumerable<Note>> GetAllNotesOfSubject(int subjectId)
        {
            try
            {
                return await _context.Notes.Where(n => n.subjectID == subjectId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new GetRequestException(ex.Message);
            }
        }

        public async Task<Note> GetNoteById(int noteId)
        {
            return await _context.Notes.FirstOrDefaultAsync(n => n.noteID == noteId);
        }

        public async Task DeleteNoteById(int noteId)
        {
            var result = await _context.Notes.FirstOrDefaultAsync(n => n.noteID == noteId);

            if (result != null)
            {
                _context.Notes.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateRatingOfNote(int noteId, int ratingValue)
        {
            var result = await _context.Notes.FirstOrDefaultAsync(n => n.noteID == noteId);

            if (result != null)
            {
                var numberOfRatings = result.numberOfRatings;
                if (numberOfRatings == 0)
                {
                    result.noteRatingValue = ratingValue;
                    numberOfRatings += 1;
                    result.numberOfRatings = numberOfRatings;
                }
                else
                {
                    var newRatingValue = result.noteRatingValue;
                    newRatingValue = newRatingValue * numberOfRatings;
                    newRatingValue = newRatingValue + ratingValue;
                    numberOfRatings += 1;
                    newRatingValue = newRatingValue / numberOfRatings;
                    result.noteRatingValue = newRatingValue;
                    result.numberOfRatings = numberOfRatings;
                    
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
