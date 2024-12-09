using Microsoft.EntityFrameworkCore;
using Student_Registration.Domain;

namespace Student_Registration.Infrastructure.Context
{
    public class StudentRegistrationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentRegistrationDbContext(DbContextOptions<StudentRegistrationDbContext> options) : base(options)
        {
        }
    }
}
