using SapinotesAPI.Data.Models;
using SapinotesAPI.Data.Responses;
using SapinotesAPI.Data.Requests;
using SapinotesAPI.Exceptions;
using SapinotesAPI.Repositories;
using SapinotesAPI.Utils;
using System.ComponentModel;

namespace SapinotesAPI.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _majorrepository;
        public MajorService(IMajorRepository majorrepository)
        {
            _majorrepository = majorrepository;
        }

        public async Task<MajorResponse> AddNewMajor(MajorRequest newMajor)
        {
            Major major = new Major()
            {
                majorName = newMajor.majorName
            };

             MajorResponse response = new MajorResponse();

            try
            {
                response.Major = await _majorrepository.AddNewMajor(major);
                if (response.Major != null)
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
