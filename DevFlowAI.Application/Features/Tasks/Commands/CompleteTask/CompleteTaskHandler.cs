using DevFlowAI.Domain.Interfaces;
using MediatR;

namespace DevFlowAI.Application.Features.Tasks.Commands.CompleteTask;

public class CompleteTaskHandler : IRequestHandler<CompleteTaskCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;

    public CompleteTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Unit> Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId);

        if (task is null)
            throw new InvalidOperationException("Tarefa não encontrada.");

        task.Complete();

        await _taskRepository.UpdateAsync(task);

        return Unit.Value;
    }
}