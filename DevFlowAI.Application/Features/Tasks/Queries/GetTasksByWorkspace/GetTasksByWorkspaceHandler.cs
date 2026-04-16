using DevFlowAI.Application.Features.Tasks.DTOs;
using DevFlowAI.Domain.Interfaces;
using MediatR;

namespace DevFlowAI.Application.Features.Tasks.Queries.GetTasksByWorkspace;

public class GetTasksByWorkspaceHandler : IRequestHandler<GetTasksByWorkspaceQuery, List<TaskDto>>
{
    private readonly ITaskRepository _repository;

    public GetTasksByWorkspaceHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TaskDto>> Handle(GetTasksByWorkspaceQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _repository.GetByWorkspaceIdAsync(request.WorkspaceId);

        return tasks.Select(task => new TaskDto
        {
            Id = task.Id,
            WorkspaceId = task.WorkspaceId,
            Title = task.Title,
            Description = task.Description,
            Completed = task.Completed,
            CreatedAt = task.CreatedAt
        }).ToList();
    }
}