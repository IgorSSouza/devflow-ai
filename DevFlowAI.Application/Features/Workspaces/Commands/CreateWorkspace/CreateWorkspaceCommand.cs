using MediatR;

namespace DevFlowAI.Application.Features.Workspaces.Commands.CreateWorkspace;

public class CreateWorkspaceCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
}