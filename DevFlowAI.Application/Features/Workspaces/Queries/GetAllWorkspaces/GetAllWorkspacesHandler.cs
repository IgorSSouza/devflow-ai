using DevFlowAI.Application.Features.Workspaces.DTOs;
using DevFlowAI.Domain.Interfaces;
using MediatR;

namespace DevFlowAI.Application.Features.Workspaces.Queries.GetAllWorkspaces;

public class GetAllWorkspacesHandler : IRequestHandler<GetAllWorkspacesQuery, List<WorkspaceDto>>
{
    private readonly IWorkspaceRepository _repository;

    public GetAllWorkspacesHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WorkspaceDto>> Handle(GetAllWorkspacesQuery request, CancellationToken cancellationToken)
    {
        var workspaces = await _repository.GetAllAsync();

        return workspaces.Select(workspace => new WorkspaceDto
        {
            Id = workspace.Id,
            Name = workspace.Name,
            CreatedAt = workspace.CreatedAt
        }).ToList();
    }
}