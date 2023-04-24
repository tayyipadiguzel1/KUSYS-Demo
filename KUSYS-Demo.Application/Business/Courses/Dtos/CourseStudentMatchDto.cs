namespace KUSYS_Demo.Application.Business.Courses.Dtos;

/// <summary>
/// CourseStudentMatchDto
/// </summary>
public class CourseStudentMatchDto
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public string CourseName { get; set; }
    public string StudentName { get; set; }
}