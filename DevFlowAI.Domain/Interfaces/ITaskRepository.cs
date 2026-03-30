using DevFlowAI.Domain.Entities;

namespace DevFlowAI.Domain.Interfaces;

public interface ITaskRepository
{
    Task AddAsync(TaskItem task);
    Task<List<TaskItem>> GetAllAsync();
}