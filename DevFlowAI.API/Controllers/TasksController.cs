using DevFlowAI.Application.Features.Tasks.Commands.CompleteTask;
using DevFlowAI.Application.Features.Tasks.Commands.CreateTask;
using DevFlowAI.Application.Features.Tasks.Queries.GetTasksByWorkspace;
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

    [HttpGet("workspace/{workspaceId:guid}")]
    public async Task<IActionResult> GetByWorkspace(Guid workspaceId)
    {
        var tasks = await _mediator.Send(new GetTasksByWorkspaceQuery(workspaceId));
        return Ok(tasks);
    }

    [HttpPatch("{taskId:guid}/complete")]
    public async Task<IActionResult> Complete(Guid taskId)
    {
        await _mediator.Send(new CompleteTaskCommand(taskId));
        return Ok(new { message = "Tarefa concluída com sucesso." });
    }
}