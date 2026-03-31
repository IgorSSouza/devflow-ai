using DevFlowAI.Domain.Entities;

namespace DevFlowAI.Domain.Interfaces;

public interface IWorkspaceRepository
{
    Task AddAsync(Workspace workspace);
}