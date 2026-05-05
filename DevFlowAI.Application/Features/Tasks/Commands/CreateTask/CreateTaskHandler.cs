using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevFlowAI.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _repository;
    private readonly ILogger<CreateTaskHandler> _logger;

    public CreateTaskHandler(
        ITaskRepository repository,
        ILogger<CreateTaskHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Iniciando criação de task para workspace {WorkspaceId} com título {TaskTitle}",
            request.WorkspaceId,
            request.Title);

        var task = new TaskItem(
            request.WorkspaceId,
            request.Title,
            request.Description);

        await _repository.AddAsync(task);

        _logger.LogInformation("Task {TaskId} criada com sucesso no workspace {WorkspaceId}", task.Id, request.WorkspaceId);

        return task.Id;
    }
}