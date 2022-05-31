using SapinotesAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SapinotesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Major> Majors { get; set; }
    }
}
