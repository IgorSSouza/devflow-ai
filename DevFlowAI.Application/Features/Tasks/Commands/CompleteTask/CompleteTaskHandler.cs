using DevFlowAI.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevFlowAI.Application.Features.Tasks.Commands.CompleteTask;

public class CompleteTaskHandler : IRequestHandler<CompleteTaskCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;
    private readonly ILogger<CompleteTaskHandler> _logger;

    public CompleteTaskHandler(
        ITaskRepository taskRepository,
        ILogger<CompleteTaskHandler> logger)
    {
        _taskRepository = taskRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando conclusão da tarefa {TaskId}", request.TaskId);

        var task = await _taskRepository.GetByIdAsync(request.TaskId);

        if (task is null)
        {
            _logger.LogWarning("Tentativa de concluir tarefa inexistente {TaskId}", request.TaskId);
            throw new InvalidOperationException("Tarefa não encontrada.");
        }

        task.Complete();

        await _taskRepository.UpdateAsync(task);

        _logger.LogInformation("Tarefa {TaskId} concluída com sucesso", request.TaskId);

        return Unit.Value;
    }
}