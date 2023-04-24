using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.StudentCourses;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Students;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Users;
using KUSYS_Demo.Domain.Data.GenericRepositories;

namespace KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;

/// <summary>
/// IUnitOfWorks
/// </summary>
public interface IUnitOfWork : IDisposable
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
    
    
    GenericRepository<Student> Student { get; }
    GenericRepository<StudentCourse> StudentCourse { get; }
    GenericRepository<User> User { get; }
}