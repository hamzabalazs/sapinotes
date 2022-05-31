using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Repositories
{
    public interface ISubjectRepository
    {
        public Task<Subject> AddNewSubject(Subject newSubject);
        public Task<Subject> GetSubjectById(int subjectId);
        public Task DeleteSubjectById(int subjectId);
        public Task<IEnumerable<Subject>> GetSubjectsByMajorId(int majorId);
    }
}
