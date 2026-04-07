using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;

namespace DevFlowAI.Infrastructure.Repositories;

public class InMemoryWorkspaceRepository : IWorkspaceRepository
{
    private static readonly List<Workspace> _workspaces = new();

    public Task AddAsync(Workspace workspace)
    {
        _workspaces.Add(workspace);
        return Task.CompletedTask;
    }
    public Task<List<Workspace>> GetAllAsync()
    {
        return Task.FromResult(_workspaces);
    }
}