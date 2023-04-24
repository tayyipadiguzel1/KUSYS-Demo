using AutoMapper;
using AutoMapper.QueryableExtensions;
using KUSYS_Demo.Application.Business.Students.Dtos;
using KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Application.Business.Students.Queries;

/// <summary>
/// GetStudentQuery
/// </summary>
public class GetStudentQuery : IRequest<StudentDto>
{
    public Guid Id { get; set; }
}

/// <summary>
/// GetStudentHandler
/// </summary>
public class GetStudentHandler : IRequestHandler<GetStudentQuery, StudentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var student = await _unitOfWork.Student.ListNt(a => a.Id == request.Id)
            .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        
        return student;
    }
}