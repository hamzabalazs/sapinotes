using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Data.Responses
{
    public class NoteResponse
    {
        public Note? Note { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
