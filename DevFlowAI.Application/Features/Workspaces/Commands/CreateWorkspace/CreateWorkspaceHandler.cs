using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using MediatR;

namespace DevFlowAI.Application.Features.Workspaces.Commands.CreateWorkspace;

public class CreateWorkspaceHandler : IRequestHandler<CreateWorkspaceCommand>
{
    private readonly IWorkspaceRepository _repository;

    public CreateWorkspaceHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        var workspace = new Workspace(request.Name);

        await _repository.AddAsync(workspace);
    }
}