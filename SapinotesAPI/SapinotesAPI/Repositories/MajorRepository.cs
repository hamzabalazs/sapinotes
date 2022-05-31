using SapinotesAPI.Data;
using SapinotesAPI.Data.Models;
using SapinotesAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace SapinotesAPI.Repositories
{
    public class MajorRepository : IMajorRepository
    {
        private readonly AppDbContext _context;
        public MajorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Major> AddNewMajor(Major newMajor)
        {
            try
            {
                var addresponse = _context.Majors.Add(newMajor);
                await _context.SaveChangesAsync();

                return addresponse.Entity;
            }
            catch (Exception ex)
            {
                throw new AddRequestException(ex.Message);
            }
        }

        public async Task DeleteMajorById(int majorId)
        {
            var result = await _context.Majors.FirstOrDefaultAsync(m => m.majorID == majorId);

            if (result != null)
            {
                _context.Majors.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Major> GetMajorById(int majorId)
        {
            return await _context.Majors.FirstOrDefaultAsync(m => m.majorID == majorId);
        }
    }
}
