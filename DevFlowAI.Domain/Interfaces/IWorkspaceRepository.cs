using DevFlowAI.Domain.Entities;

namespace DevFlowAI.Domain.Interfaces;

public interface IWorkspaceRepository
{
    Task AddAsync(Workspace workspace);
    Task<List<Workspace>> GetAllAsync();
}