using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;

public class CreateTaskHandler
{
    private readonly ITaskRepository _repository;

    public CreateTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(CreateTaskCommand command)
    {
        var task = new TaskItem(command.Title, command.Description);
        await _repository.AddAsync(task);
    }
}