using Microsoft.EntityFrameworkCore;
using Student_Registration.Application.Interfaces;
using Student_Registration.Domain.Dtos.StudentsDto;
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

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRegistrationContext.Students.FindAsync(id);
        }


        public async Task AddStudentAsync(Student student)
        {
            var existingStudent = await GetStudentByIdAsync(student.Id);
            if (existingStudent != null)
            {
                throw new InvalidOperationException($"A student with ID {student.Id} already exists.");
            }

            await _studentRegistrationContext.Students.AddAsync(student);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _studentRegistrationContext.SaveChangesAsync()) > 0;
        }

    }
}
