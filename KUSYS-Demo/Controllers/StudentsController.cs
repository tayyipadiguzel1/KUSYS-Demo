using KUSYS_Demo.Application.Business.Students.Commands;
using KUSYS_Demo.Application.Business.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers;

public class StudentsController : Controller
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
    {
        var response = await _mediator.Send(command);
        if (response != null)
            return Ok(response);

        return NoContent();
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteStudentCommand command)
    {
        var response = await _mediator.Send(command);
        if (response)
            return Ok(response);

        return BadRequest();
    }
    
    /// <summary>
    /// Update
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DeleteStudentCommand command)
    {
        var response = await _mediator.Send(command);
        if (response)
            return Ok(response);

        return BadRequest();
    }
    
    /// <summary>
    /// List
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult List([FromQuery] ListStudentQuery query)
    {
        var response =  _mediator.Send(query).GetAwaiter().GetResult();
        return response.Any() ? View(response) : View("Error");
    }
    
    
}