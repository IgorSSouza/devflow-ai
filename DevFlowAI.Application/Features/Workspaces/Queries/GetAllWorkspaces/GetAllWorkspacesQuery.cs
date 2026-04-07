using MediatR;
using DevFlowAI.Application.Features.Workspaces.DTOs;

namespace DevFlowAI.Application.Features.Workspaces.Queries.GetAllWorkspaces;

public class GetAllWorkspacesQuery : IRequest<List<WorkspaceDto>>
{
}