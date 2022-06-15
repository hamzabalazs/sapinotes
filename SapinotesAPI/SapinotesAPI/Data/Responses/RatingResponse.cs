using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Data.Responses
{
    public class RatingResponse
    {
        public Rating? Rating { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
