using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using DevFlowAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFlowAI.Infrastructure.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly AppDbContext _context;

    public WorkspaceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Workspace workspace)
    {
        await _context.Workspaces.AddAsync(workspace);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Workspace>> GetAllAsync()
    {
        return await _context.Workspaces
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();
    }
}