using SapinotesAPI.Data.Requests;
using SapinotesAPI.Data.Responses;

namespace SapinotesAPI.Services
{
    public interface IMajorService
    {
        public Task<MajorResponse> AddNewMajor(MajorRequest newMajor);
    }
}
