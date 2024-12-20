using Student_Registration.Domain.Entities.StudentsEntities;

namespace Student_Registration.Application.Interfaces
{
    public interface IStudentRegistrationRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        //Task<int> CreateStudentAsync(Student student);
        Task AddStudentAsync(Student student);

        Task<bool> SaveChangesAsync();

        Task DeleteStudentAsync(int studentId);
    }
}
