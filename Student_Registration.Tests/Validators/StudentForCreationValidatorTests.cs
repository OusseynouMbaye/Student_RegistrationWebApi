using FluentValidation.TestHelper;
using Student_Registration.Webui.Dtos.StudentsDtos;
using Student_Registration.Webui.Dtos.StudentsDtosValidator;
using Xunit;


namespace Student_Registration.Tests.Validators
{
    public class StudentForCreationValidatorTests
    {
        private readonly StudentForCreationValidator _validator;

        public StudentForCreationValidatorTests()
        {
            _validator = new StudentForCreationValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenNameIsNull()
        {
            var student = new StudentForCreation { Name = null, Age = 20 };
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(student => student.Name);
        }


        //// error when name is longer than 50 characters 
        //// need a failure test instead of a success test
        [Fact]
        public void ShouldHaveErrorWhenNameIsLongerThan50Characters()
        {
            var student = new StudentForCreation { Name = "12345678901234567890123456789012345678901234567891234", Age = 20 };
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(student => student.Name).WithoutErrorMessage("Name should be less than 50 characters");
        }

        #region  Age  
        // test when age is null 
        // ce test est valide seulement si je dis que age est obligatoire ou
        [Fact]
        public void ShouldHaveErrorWhenAgeIsNull()
        {
            var student = new StudentForCreation { Name = "John", Age = null };
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(student => student.Age).WithErrorMessage("Age must be between 10 and 30.");
        }

        //[Fact]
        //public void ShouldHaveErrorWhenAgeIsLessThan10()
        //{
        //    var student = new StudentForCreation { Name = "John", Age = 9 };
        //    var result = _validator.TestValidate(student);
        //    result.ShouldHaveValidationErrorFor(student => student.Age).WithErrorMessage("Age must be between 10 and 30.");
        //}

        //[Fact]
        //public void ShouldHaveErrorWhenAgeIsGreaterThan30()
        //{
        //    var student = new StudentForCreation { Name = "John", Age = 33 };
        //    var result = _validator.TestValidate(student);
        //    result.ShouldHaveValidationErrorFor(student => student.Age).WithErrorMessage("Age must be between 10 and 30.");
        //}
        #endregion



    }
}
