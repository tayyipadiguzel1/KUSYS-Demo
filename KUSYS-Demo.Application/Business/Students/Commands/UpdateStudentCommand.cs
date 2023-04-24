using KUSYS_Demo.Application.Business.Students.Dtos;
using KUSYS_Demo.Application.Business.Students.Queries;
using KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;
using MediatR;

namespace KUSYS_Demo.Application.Business.Students.Commands;

/// <summary>
/// UpdateStudentCommand
/// </summary>
public class UpdateStudentCommand : StudentDto, IRequest<StudentDto>
{
    public Guid Id { get; set; }
}

/// <summary>
/// UpdateStudentHandler
/// </summary>
public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, StudentDto>
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;

    public UpdateStudentHandler(IUnitOfWork uow, ISender sender)
    {
        _uow = uow;
        _sender = sender;
    }

    public async Task<StudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _uow.Student.FindAsync(a => a.Id == request.Id);
        if (student == null)
            return null;

        student.BirthDate = request.BirthDate;
        student.FirstName = request.FirstName;
        student.LastName = request.LastName;

        _uow.Student.Edit(student);
        await _uow.SaveChangesAsync();

        return await _sender.Send(new GetStudentQuery() {Id = student.Id}, CancellationToken.None);
    }
}