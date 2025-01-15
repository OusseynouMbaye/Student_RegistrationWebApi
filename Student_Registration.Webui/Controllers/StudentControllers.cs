using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Student_Registration.Application.Interfaces;
using Student_Registration.Domain.Entities.StudentsEntities;
using Student_Registration.Webui.Dtos.StudentsDtos;


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

            if (student == null)
            {
                return NotFound($"Student with ID {studentId} not found.");
            }

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

        [HttpPatch("{studentId}")]
        public async Task<IActionResult> UpdateStudentPartiallyAsync(int studentId, [FromBody] JsonPatchDocument<Student> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest("Patch document is null");
            }

            // Récupérer l'étudiant depuis le repository
            var studentEntity = await _studentRegistrationRepository.GetStudentByIdAsync(studentId);
            if (studentEntity == null)
            {
                return NotFound($"Student with ID {studentId} not found.");
            }

            // Appliquer le patch au modèle récupéré
            patchDocument.ApplyTo(studentEntity);
            //patchDocument.ApplyTo(studentEntity, ModelState);

            // Vérifier si le modèle est valide après application
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            // Sauvegarder les modifications
            await _studentRegistrationRepository.UpdateStudentAsync(studentEntity);
            await _studentRegistrationRepository.SaveChangesAsync();

            return NoContent(); // Répond avec un 204 No Content pour indiquer que tout s'est bien passé
        }


        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudentAsync(int studentId)
        {
            try
            {
                // Appelle la méthode de suppression du dépôt
                await _studentRegistrationRepository.DeleteStudentAsync(studentId);

                // Sauvegarde les changements
                await _studentRegistrationRepository.SaveChangesAsync();

                // Retourne un statut 204 No Content
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                // Retourne un statut 404 si l'étudiant n'existe pas
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Retourne un statut 500 en cas d'erreur interne
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
