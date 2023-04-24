using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.StudentCourses;
using KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;
using MediatR;

namespace KUSYS_Demo.Application.Business.Courses.Commands;

public class SetCourseToStudentCommand : IRequest<bool>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}


public class SetCourseToStudentHandler : IRequestHandler<SetCourseToStudentCommand, bool>
{
    private readonly IUnitOfWork _uow;
    
    public SetCourseToStudentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }
    
    public async Task<bool> Handle(SetCourseToStudentCommand request, CancellationToken cancellationToken)
    {
        var courseIsExists = await _uow.StudentCourse.AnyAsync(a => a.CourseId == request.CourseId);
        if (!courseIsExists)
            return false;
        
        var isStudentHasCourse = await _uow.StudentCourse.AnyAsync(a => a.CourseId == request.CourseId && a.StudentId == request.StudentId);
        if (isStudentHasCourse)
            return false;

        var studentCourse = new StudentCourse()
        {
            StudentId = request.StudentId,
            CourseId = request.CourseId
        };
        
         _uow.StudentCourse.Create(studentCourse);
         await _uow.SaveChangesAsync();

         return true;
        
    }
}