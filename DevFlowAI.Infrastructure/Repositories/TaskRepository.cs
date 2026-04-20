using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using DevFlowAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFlowAI.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TaskItem task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<TaskItem>> GetByWorkspaceIdAsync(Guid workspaceId)
    {
        return await _context.Tasks
            .Where(x => x.WorkspaceId == workspaceId)
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();
    }
}