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
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
