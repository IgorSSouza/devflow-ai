using DevFlowAI.Application.Features.AI.Commands.GeneratePlan;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFlowAI.API.Controllers;

[ApiController]
[Route("api/ai")]
public class AIController : ControllerBase
{
    private readonly IMediator _mediator;

    public AIController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("generate-plan")]
    public async Task<IActionResult> GeneratePlan([FromBody] GeneratePlanCommand command)
    {
        var createdTaskIds = await _mediator.Send(command);

        return Ok(new
        {
            message = "Plano gerado com sucesso.",
            taskIds = createdTaskIds
        });
    }
}