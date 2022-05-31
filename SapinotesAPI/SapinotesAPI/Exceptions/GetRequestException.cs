namespace SapinotesAPI.Exceptions
{
    public class GetRequestException : Exception
    {
        public GetRequestException()
        {

        }

        public GetRequestException(string? message) : base(message)
        {

        }
    }
}
