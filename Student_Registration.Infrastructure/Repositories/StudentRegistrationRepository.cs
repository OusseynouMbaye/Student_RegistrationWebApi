using Microsoft.EntityFrameworkCore;
using Student_Registration.Application.Interfaces;
using Student_Registration.Domain.Entities.StudentsEntities;
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

        public async Task UpdateStudentAsync(Student student)
        {
            var existingStudent = await GetStudentByIdAsync(student.Id);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException($"No student found with ID {student.Id}.");
            }

            _studentRegistrationContext.Students.Update(student);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _studentRegistrationContext.SaveChangesAsync()) > 0;
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var student = await GetStudentByIdAsync(studentId);
            if (student == null)
            {
                throw new KeyNotFoundException($"No student found with ID {studentId}.");
            }

            _studentRegistrationContext.Students.Remove(student);
        }


    }
}
