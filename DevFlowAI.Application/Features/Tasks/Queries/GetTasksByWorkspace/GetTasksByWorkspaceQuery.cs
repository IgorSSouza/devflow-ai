using DevFlowAI.Application.Features.Tasks.DTOs;
using MediatR;

namespace DevFlowAI.Application.Features.Tasks.Queries.GetTasksByWorkspace;

public class GetTasksByWorkspaceQuery : IRequest<List<TaskDto>>
{
    public Guid WorkspaceId { get; set; }

    public GetTasksByWorkspaceQuery(Guid workspaceId)
    {
        WorkspaceId = workspaceId;
    }
}