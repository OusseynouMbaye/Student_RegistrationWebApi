using Microsoft.AspNetCore.Mvc;
using Student_Registration.Application.Interfaces;
using Student_Registration.Domain.Dtos.StudentsDto;

namespace Student_Registration.Webui.Controllers
{
    [ApiController]
    [Route("api/students/")]
    public class StudentControllers : Controller
    {
        private readonly IStudentRegistrationRepository _studentRegistrationRepository;

        public StudentControllers(IStudentRegistrationRepository studentRegistrationRepository)
        {
            _studentRegistrationRepository = studentRegistrationRepository ?? throw new ArgumentNullException(nameof(studentRegistrationRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _studentRegistrationRepository.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{studentId}", Name = "GetStudentByIdAsync")]
        public async Task<IActionResult> GetStudentByIdAsync(int studentId)
        {

            var student = await _studentRegistrationRepository.GetStudentByIdAsync(studentId);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] StudentForCreation newStudent)
        {
            if (newStudent == null)
            {
                return BadRequest("Student object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Création de l'entité Student
            var studentEntity = new Student(
                Id: 0, // Laisse l'ID à 0 ou omets-le si auto-généré
                Name: newStudent.Name,
                Age: newStudent.Age,
                Address: newStudent.Address,
                Gender: newStudent.Gender,
                PhoneNum: newStudent.PhoneNum
            );

            // Ajout au dépôt
            await _studentRegistrationRepository.AddStudentAsync(studentEntity);
            await _studentRegistrationRepository.SaveChangesAsync();

            // Retourne une réponse Created avec l'URI de la ressource
            return CreatedAtRoute("GetStudentByIdAsync", new { studentId = studentEntity.Id }, studentEntity);
        }

    }
}
