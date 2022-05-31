using SapinotesAPI.Data;
using SapinotesAPI.Data.Models;
using SapinotesAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace SapinotesAPI.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Subject> AddNewSubject(Subject newSubject)
        {
            try
            {
                var addresponse = _context.Subjects.Add(newSubject);
                await _context.SaveChangesAsync();

                return addresponse.Entity;
            }
            catch (Exception ex)
            {
                throw new AddRequestException(ex.Message);
            }

        }

        public async Task DeleteSubjectById(int subjectId)
        {
            var result = await _context.Subjects.FirstOrDefaultAsync(s => s.subjectID == subjectId);

            if (result != null)
            {
                _context.Subjects.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Subject> GetSubjectById(int subjectId)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.subjectID == subjectId);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByMajorId(int majorId)
        {
            try
            {
                return await _context.Subjects.Where(s => s.majorID == majorId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new GetRequestException(ex.Message);
            }
        }
    }
}
