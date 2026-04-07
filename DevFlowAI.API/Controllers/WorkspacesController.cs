using DevFlowAI.Application.Features.Workspaces.Commands.CreateWorkspace;
using DevFlowAI.Application.Features.Workspaces.Queries.GetAllWorkspaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFlowAI.API.Controllers;

[ApiController]
[Route("api/workspaces")]
public class WorkspacesController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkspacesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorkspaceCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workspaces = await _mediator.Send(new GetAllWorkspacesQuery());
        return Ok(workspaces);
    }
}