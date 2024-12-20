namespace Student_Registration.Domain.Entities.StudentsEntities
{
    public record StudentForCreation(string Name, int? Age, string? Address, string? Gender, string? PhoneNum);
}
