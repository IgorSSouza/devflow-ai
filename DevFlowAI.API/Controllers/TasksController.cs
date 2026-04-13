using DevFlowAI.Application.Features.Tasks.Commands.CreateTask;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFlowAI.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { id });
    }
}