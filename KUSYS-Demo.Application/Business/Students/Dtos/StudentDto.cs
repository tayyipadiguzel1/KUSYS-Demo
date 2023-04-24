namespace KUSYS_Demo.Application.Business.Students.Dtos;

/// <summary>
/// StudentDto
/// </summary>
public class StudentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}