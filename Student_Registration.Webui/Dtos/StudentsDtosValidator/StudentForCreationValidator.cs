using FluentValidation;
using Student_Registration.Webui.Dtos.StudentsDtos;

namespace Student_Registration.Webui.Dtos.StudentsDtosValidator
{
    public class StudentForCreationValidator : AbstractValidator<StudentForCreation>
    {
        public StudentForCreationValidator()
        {
            RuleFor(student => student.Name).NotEmpty().WithMessage("You should provide a name value.").MaximumLength(50);

            RuleFor(student => student.Age).InclusiveBetween(10, 30).WithMessage("Age must be between 10 and 30.");
        }
    }
}
