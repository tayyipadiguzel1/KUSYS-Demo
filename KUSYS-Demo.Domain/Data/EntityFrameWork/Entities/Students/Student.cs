namespace KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Students;

/// <summary>
/// Student
/// </summary>
public class Student : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}