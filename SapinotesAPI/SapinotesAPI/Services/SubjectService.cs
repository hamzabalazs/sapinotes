using SapinotesAPI.Data.Models;
using SapinotesAPI.Data.Responses;
using SapinotesAPI.Data.Requests;
using SapinotesAPI.Exceptions;
using SapinotesAPI.Repositories;
using SapinotesAPI.Utils;
using System.ComponentModel;

namespace SapinotesAPI.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<SubjectResponse> AddNewSubject(SubjectRequest newSubject)
        {
            Subject subject = new Subject()
            {
                subjectName = newSubject.subjectName,
                majorID = newSubject.majorID

            };

            SubjectResponse response = new SubjectResponse();

            try
            {
                response.Subject = await _subjectRepository.AddNewSubject(subject);
                if (response.Subject != null)
                {
                    response.Message = "Successful!";
                    response.Code = 200;
                }
                return response;
            }
            catch (AddRequestException ex)
            {
                throw new AddException(ex.Message);
            }

        }
    }
}
