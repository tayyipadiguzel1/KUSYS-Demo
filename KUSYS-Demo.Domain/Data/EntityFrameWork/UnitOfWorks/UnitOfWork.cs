using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.StudentCourses;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Students;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Users;
using KUSYS_Demo.Domain.Data.GenericRepositories;

namespace KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// SaveChanges
    /// </summary>
    /// <returns></returns>
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    /// <summary>
    /// SaveChangesAsync
    /// </summary>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }


    private GenericRepository<Student> _student;
    public GenericRepository<Student> Student => _student ??= T<Student>();
    
    
    private GenericRepository<StudentCourse> _studentCourse;
    public GenericRepository<StudentCourse> StudentCourse => _studentCourse ??= T<StudentCourse>();
    
    private GenericRepository<User> _user;
    public GenericRepository<User> User => _user ??= T<User>();


    /// <summary>
    /// T
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public GenericRepository<TEntity> T<TEntity>() where TEntity : BaseEntity
    {
        var dbSet = _context.Set<TEntity>();
        return new GenericRepository<TEntity>(dbSet, _context);
    }


    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}