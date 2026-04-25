using MediatR;

namespace DevFlowAI.Application.Features.AI.Commands.GeneratePlan;

public class GeneratePlanCommand : IRequest<List<Guid>>
{
    public Guid WorkspaceId { get; set; }
    public string Goal { get; set; } = string.Empty;
}