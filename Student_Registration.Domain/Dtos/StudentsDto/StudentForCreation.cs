namespace Student_Registration.Domain.Dtos.StudentsDto
{
    public record StudentForCreation(string Name, int? Age, string? Address, string? Gender, string? PhoneNum);
}
