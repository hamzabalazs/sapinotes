using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Repositories
{
    public interface INoteRepository
    {
        public Task<Note> AddNewNote(Note note);
        public Task<IEnumerable<Note>> GetAllNotesOfUser(int userId);
        public Task<IEnumerable<Note>> GetAllNotesOfSubject(int subjectId);
        public Task DeleteNoteById(int noteId);
        public Task<Note> GetNoteById(int noteId);

        
    }
}
