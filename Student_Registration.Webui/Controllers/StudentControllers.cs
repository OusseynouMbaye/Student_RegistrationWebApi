using Microsoft.AspNetCore.Mvc;
using Student_Registration.Application.Interfaces;
using Student_Registration.Domain;

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

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentByIdAsync(int studentId)
        {

            var student = await _studentRegistrationRepository.GetStudentByIdAsync(studentId);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _studentRegistrationRepository.CreateStudentAsync(student);
                return CreatedAtRoute(nameof(GetStudentByIdAsync), new { id = student.id }, student);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
