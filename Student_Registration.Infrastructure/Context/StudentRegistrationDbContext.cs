using Microsoft.EntityFrameworkCore;
using Student_Registration.Domain.Dtos.StudentsDto;

namespace Student_Registration.Infrastructure.Context
{
    public class StudentRegistrationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentRegistrationDbContext(DbContextOptions<StudentRegistrationDbContext> options) : base(options)
        {
        }

        // To delete a migration, use the following command in the Package Manager Console:
        // Remove-Migration -Context StudentRegistrationDbContext

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "YourConnectionStringHere",
        //        b => b.MigrationsAssembly("Student_Registration.Webui"));
        //}
    }
}
