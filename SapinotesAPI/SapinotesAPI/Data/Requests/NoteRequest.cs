namespace SapinotesAPI.Data.Requests
{
    public class NoteRequest
    {
        public int userID { get; set; }
        public int subjectID { get; set; }
        public string noteName { get; set; }
        public int noteDocID { get; set; }
    }
}
