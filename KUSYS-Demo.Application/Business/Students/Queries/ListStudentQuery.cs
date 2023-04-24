using AutoMapper;
using AutoMapper.QueryableExtensions;
using KUSYS_Demo.Application.Business.Students.Dtos;
using KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Application.Business.Students.Queries;

/// <summary>
/// ListStudentQuery
/// </summary>
public class ListStudentQuery : IRequest<List<StudentDto>>
{
    
}


/// <summary>
/// ListStudentHandler
/// </summary>
public class ListStudentHandler : IRequestHandler<ListStudentQuery, List<StudentDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    
    public ListStudentHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<List<StudentDto>> Handle(ListStudentQuery request, CancellationToken cancellationToken)
    {
        var students = await _uow.Student.TableNoTracking
            .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return students;
    }
}