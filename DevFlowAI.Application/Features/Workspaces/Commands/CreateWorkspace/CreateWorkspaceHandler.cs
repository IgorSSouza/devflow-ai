using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;

public class CreateWorkspaceHandler
{
    private readonly IWorkspaceRepository _repository;

    public CreateWorkspaceHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(CreateWorkspaceCommand command)
    {
        var workspace = new Workspace(command.Name);

        await _repository.AddAsync(workspace);
    }
}