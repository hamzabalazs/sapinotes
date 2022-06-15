using SapinotesAPI.Data.Models;
using SapinotesAPI.Data.Requests;
using SapinotesAPI.Data.Responses;
using SapinotesAPI.Exceptions;
using SapinotesAPI.Repositories;
using SapinotesAPI.Utils;
using System.ComponentModel;

namespace SapinotesAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NoteResponse> AddNewNote(NoteRequest newNote)
        {
            Note note = new Note()
            {
                userID = newNote.userID,
                username = newNote.username,
                subjectID = newNote.subjectID,
                noteName = newNote.noteName,
                noteDocID = newNote.noteDocID,
                noteRatingValue = newNote.noteRatingValue,
                numberOfRatings = newNote.numberOfRatings
            };

            NoteResponse response = new NoteResponse();

            try
            {
                response.Note = await _noteRepository.AddNewNote(note);
                if (response.Note != null)
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
