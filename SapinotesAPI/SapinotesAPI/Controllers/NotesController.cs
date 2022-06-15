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
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly INoteService _noteService;

        public NotesController(INoteRepository noteRepository, INoteService noteService)
        {
            _noteRepository = noteRepository;
            _noteService = noteService;
        }
        [HttpPost, Route("add-new-note")]
        public async Task<ActionResult<Note>> PostNote([FromBody] NoteRequest note)
        {
            try
            {
                NoteResponse result = await _noteService.AddNewNote(note);
                return Ok(result);
            }
            catch (AddException ex)
            {
                NoteResponse errorResponse = new NoteResponse()
                {
                    Code = 400,
                    Message = APIErrorCodes.ADD_REQUEST_EXCEPTION_MESSAGE + ex.Message
                };
                return BadRequest(errorResponse);
            }
        }
        [HttpGet, Route("get-notes-of-user")]
        public async Task<ActionResult> GetNotesByUser(int userId)
        {
            try
            {
                return Ok(await _noteRepository.GetAllNotesOfUser(userId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet, Route("get-notes-of-subject")]
        public async Task<ActionResult> GetNotesBySubject(int subjectId)
        {
            try
            {
                return Ok(await _noteRepository.GetAllNotesOfSubject(subjectId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete, Route("delete-note-by-id")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            try
            {
                var noteToDelete = await _noteRepository.GetNoteById(id);

                if (noteToDelete == null)
                {
                    return NotFound();
                }

                await _noteRepository.DeleteNoteById(id);
                return Ok();


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting note");
            }

        }
        [HttpPut, Route("update-rating-of-note")]
        public async Task<ActionResult> UpdateNote(int id, int ratingValue)
        {
            try
            {
                var noteToUpdate = await _noteRepository.GetNoteById(id);

                if (noteToUpdate == null)
                {
                    return NotFound();
                }

                await _noteRepository.UpdateRatingOfNote(id, ratingValue);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating rating");
            }
        }
    }
}
