using DevFlowAI.Application.Features.Workspaces.Commands.CreateWorkspace;
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
        await _mediator.Send(command);
        return Ok("Workspace criado com sucesso");
    }
}