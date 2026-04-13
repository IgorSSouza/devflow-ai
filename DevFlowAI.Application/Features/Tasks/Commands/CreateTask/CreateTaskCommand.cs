using MediatR;

namespace DevFlowAI.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommand : IRequest<Guid>
{
    public Guid WorkspaceId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}