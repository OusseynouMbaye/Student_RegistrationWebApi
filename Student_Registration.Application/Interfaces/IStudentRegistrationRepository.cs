using Student_Registration.Domain;

namespace Student_Registration.Application.Interfaces
{
    public interface IStudentRegistrationRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        //Task<int> CreateStudentAsync(Student student);
        Task<int> CreateStudentAsync(Student student);
    }
}
