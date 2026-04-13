using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using MediatR;

namespace DevFlowAI.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _repository;

    public CreateTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem(
            request.WorkspaceId,
            request.Title,
            request.Description);

        await _repository.AddAsync(task);

        return task.Id;
    }
}