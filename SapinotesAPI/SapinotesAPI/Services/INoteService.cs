using SapinotesAPI.Data.Requests;
using SapinotesAPI.Data.Responses;

namespace SapinotesAPI.Services
{
    public interface INoteService
    {
        public Task<NoteResponse> AddNewNote(NoteRequest newNote);
    }
}
