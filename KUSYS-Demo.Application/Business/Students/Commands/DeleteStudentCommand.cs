using KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;
using MediatR;

namespace KUSYS_Demo.Application.Business.Students.Commands;

/// <summary>
/// DeleteStudentCommand
/// </summary>
public class DeleteStudentCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

/// <summary>
/// DeleteStudentHandler
/// </summary>
public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
{
    private readonly IUnitOfWork _uow;

    public DeleteStudentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _uow.Student.FindAsync(a => a.Id == request.Id);
        if (student == null)
            return false;

        _uow.Student.Delete(student);
        await _uow.SaveChangesAsync();
        return true;
    }
}