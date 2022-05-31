using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Data.Responses
{
    public class MajorResponse
    {
        public Major? Major { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
