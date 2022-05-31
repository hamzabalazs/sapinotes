using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Repositories
{
    public interface IMajorRepository
    {
        public Task<Major> AddNewMajor(Major newMajor);
        public Task<Major> GetMajorById(int majorID);
        public Task DeleteMajorById(int majorID);
    }
}
