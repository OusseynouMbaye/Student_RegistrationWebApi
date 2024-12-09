using Microsoft.EntityFrameworkCore;
using Student_Registration.Application.Interfaces;
using Student_Registration.Domain;
using Student_Registration.Infrastructure.Context;

namespace Student_Registration.Infrastructure.Repositories
{
    public class StudentRegistrationRepository : IStudentRegistrationRepository
    {
        private readonly StudentRegistrationDbContext _studentRegistrationContext;

        public StudentRegistrationRepository(StudentRegistrationDbContext studentRegistrationContext)
        {
            _studentRegistrationContext = studentRegistrationContext ?? throw new ArgumentNullException(nameof(studentRegistrationContext));
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentRegistrationContext.Students.ToListAsync();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            return _studentRegistrationContext.Students.FirstOrDefaultAsync(s => s.id == id);
        }

        //public async Task CreateStudentAsync(Student student)
        //{
        //    _studentRegistrationContext.Add(student);
        //    await _studentRegistrationContext.SaveChangesAsync();
        //}

       public async Task<int> CreateStudentAsync(Student student)
        {
           _studentRegistrationContext.Add(student);
           return await _studentRegistrationContext.SaveChangesAsync();
        }
    }
}
