using KUSYS_Demo.Application.Business.Courses.Commands;
using KUSYS_Demo.Application.Business.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers;

public class CoursesController : Controller
{
    private readonly IMediator _mediator;
    
    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// SetToStudent
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SetToStudent([FromBody] SetCourseToStudentCommand command)
    {
        var response = await _mediator.Send(command);
        return response ? Ok(response) : BadRequest();
    }
    
    /// <summary>
    /// ListWithStudent
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ListWithStudent(ListCourseStudentMatchQuery query)
    {
        var response = await _mediator.Send(query);
        return View(response);
    }
}