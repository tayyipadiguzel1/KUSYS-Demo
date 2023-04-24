using AutoMapper;
using AutoMapper.QueryableExtensions;
using KUSYS_Demo.Application.Business.Courses.Dtos;
using KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Application.Business.Courses.Queries;

/// <summary>
/// ListCourseStudentMatchQuery
/// </summary>
public class ListCourseStudentMatchQuery : IRequest<List<CourseStudentMatchDto>>
{
    
}

/// <summary>
/// ListCourseStudentMatchHandler
/// </summary>
public class ListCourseStudentMatchHandler : IRequestHandler<ListCourseStudentMatchQuery, List<CourseStudentMatchDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    
    public ListCourseStudentMatchHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<List<CourseStudentMatchDto>> Handle(ListCourseStudentMatchQuery request, CancellationToken cancellationToken)
    {
        var response = await _uow.StudentCourse.TableNoTracking
            .ProjectTo<CourseStudentMatchDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return response;
    }
}