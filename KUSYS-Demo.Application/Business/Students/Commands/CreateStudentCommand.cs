using AutoMapper;
using KUSYS_Demo.Application.Business.Students.Dtos;
using KUSYS_Demo.Application.Business.Students.Queries;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Students;
using KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;
using MediatR;

namespace KUSYS_Demo.Application.Business.Students.Commands;

/// <summary>
/// CreateStudentCommand
/// </summary>
public class CreateStudentCommand : IRequest<StudentDto>
{
}

/// <summary>
/// CreateStudentHandler
/// </summary>
public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public CreateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper, ISender sender)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _sender = sender;
    }

    public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Student>(request);
        _unitOfWork.Student.Create(student);
        await _unitOfWork.SaveChangesAsync();

        return await _sender.Send(new GetStudentQuery() {Id = student.Id}, CancellationToken.None);
    }
}