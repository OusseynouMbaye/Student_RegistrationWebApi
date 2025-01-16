using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Webui.Dtos.StudentsDtos
{
    public record StudentForCreation
    {

        // I use the fluent validation library to validate the data
        //[Required(ErrorMessage ="You should provide a name value.")]
        //[MaxLength(50)]
        public string Name { get; set; } = string.Empty; //  public string Name { get; init; }
        
        //[Range(10, 30, ErrorMessage = "Age must be between 10 and 30.")]
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNum { get; set; }

    }
}
