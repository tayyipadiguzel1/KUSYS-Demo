using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.StudentCourses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KUSYS_Demo.Domain.Data.EntityFrameWork.Configurations.StudentCourses;

internal class StudentCourseConf : BaseConf<StudentCourse>
{
    public override void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.ToTable("student_courses");
        base.Configure(builder);
    }
}