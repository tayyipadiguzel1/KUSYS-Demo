using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KUSYS_Demo.Domain.Data.EntityFrameWork.Configurations;

/// <summary>
/// BaseConf
/// </summary>
/// <typeparam name="T"></typeparam>
internal abstract class BaseConf<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasQueryFilter(m => m.Deleted == false);
        builder.HasIndex(m => new { m.Deleted });
    }
}