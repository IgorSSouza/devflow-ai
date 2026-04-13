using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;

namespace DevFlowAI.Infrastructure.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private static readonly List<TaskItem> _tasks = new();

    public Task AddAsync(TaskItem task)
    {
        _tasks.Add(task);
        return Task.CompletedTask;
    }

    public Task<List<TaskItem>> GetAllAsync()
    {
        return Task.FromResult(_tasks);
    }
}