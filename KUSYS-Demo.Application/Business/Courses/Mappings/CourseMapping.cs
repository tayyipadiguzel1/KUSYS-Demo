using AutoMapper;
using KUSYS_Demo.Application.Business.Courses.Dtos;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.StudentCourses;

namespace KUSYS_Demo.Application.Business.Courses.Mappings;

/// <summary>
/// CourseMapping
/// </summary>
public class CourseMapping : Profile
{
    public CourseMapping()
    {
        CreateMap<StudentCourse, CourseStudentMatchDto>()
            .ForMember(a => a.CourseName, opt => opt.MapFrom(src => src.Course.CourseName))
            .ForMember(a => a.StudentName, opt => opt.MapFrom(src => string.Concat(src.Student.FirstName, " ", src.Student.LastName)));
    }
}