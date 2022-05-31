namespace SapinotesAPI.Exceptions
{
    public class AddRequestException : Exception
    {
        public AddRequestException()
        {
        }

        public AddRequestException(string? message) : base(message)
        {
        }
    }
}
