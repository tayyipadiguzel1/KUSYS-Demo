using AutoMapper;
using KUSYS_Demo.Application.Business.Students.Dtos;
using KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Students;

namespace KUSYS_Demo.Application.Business.Students.Mappings;

/// <summary>
/// StudentMapping
/// </summary>
public class StudentMapping : Profile
{
    public StudentMapping()
    {
        CreateMap<Student, StudentDto>().ReverseMap();
    }
}