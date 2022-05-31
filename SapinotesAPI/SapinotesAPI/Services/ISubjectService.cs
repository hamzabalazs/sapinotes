using SapinotesAPI.Data.Responses;
using SapinotesAPI.Data.Requests;

namespace SapinotesAPI.Services
{
    public interface ISubjectService
    {
        public Task<SubjectResponse> AddNewSubject(SubjectRequest newSubject);
    }
}
