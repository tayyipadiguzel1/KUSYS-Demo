using KUSYS_Demo.Domain.Data.EntityFrameWork.Configurations.StudentCourses;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Configurations.Students;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KUSYS_Demo.Domain.Data.EntityFrameWork;

public class DataContext : DbContext
{
    public virtual DbSet<Student> Students { get; set; }


    /// <summary>
    /// OnConfiguring
    /// </summary> xdx
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        base.OnConfiguring(optionsBuilder);
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json")
            .Build();
        
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MsSql")).EnableSensitiveDataLogging(environmentName == "Development");
    }

    /// <summary>
    /// OnModelCreating
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConf());
        modelBuilder.ApplyConfiguration(new StudentCourseConf());
        
        base.OnModelCreating(modelBuilder);
    }
}