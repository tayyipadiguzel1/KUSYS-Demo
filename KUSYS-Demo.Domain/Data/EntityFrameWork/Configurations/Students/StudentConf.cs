using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace KUSYS_Demo.Domain.Data.EntityFrameWork.Configurations.Students;

/// <summary>
/// StudentConf
/// </summary>
internal class StudentConf: BaseConf<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");
        base.Configure(builder);
    }
}