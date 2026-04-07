using MediatR;

namespace DevFlowAI.Application.Features.Workspaces.Commands.CreateWorkspace;

public class CreateWorkspaceCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
}