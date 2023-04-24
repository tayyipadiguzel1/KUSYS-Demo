using System.ComponentModel.DataAnnotations.Schema;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Courses;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Students;

namespace KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.StudentCourses;

/// <summary>
/// StudentCourse
/// </summary>
public class StudentCourse : BaseEntity
{
    public Guid CourseId { get; set; }
    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; }
    
    public Guid StudentId { get; set; }
    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; }
}