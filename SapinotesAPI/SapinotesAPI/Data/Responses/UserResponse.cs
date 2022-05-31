using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Data.Responses
{
    public class UserResponse
    {
        public User? User { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
