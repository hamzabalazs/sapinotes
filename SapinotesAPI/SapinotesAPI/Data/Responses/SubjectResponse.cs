using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Data.Responses
{
    public class SubjectResponse
    {
        public Subject? Subject { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
