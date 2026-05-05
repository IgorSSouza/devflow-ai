using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevFlowAI.Application.Features.Workspaces.Commands.CreateWorkspace;

public class CreateWorkspaceHandler : IRequestHandler<CreateWorkspaceCommand, Guid>
{
    private readonly IWorkspaceRepository _repository;
    private readonly ILogger<CreateWorkspaceHandler> _logger;

    public CreateWorkspaceHandler(
        IWorkspaceRepository repository,
        ILogger<CreateWorkspaceHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de workspace com nome {WorkspaceName}", request.Name);

        var workspace = new Workspace(request.Name);

        await _repository.AddAsync(workspace);

        _logger.LogInformation("Workspace {WorkspaceId} criado com sucesso", workspace.Id);

        return workspace.Id;
    }
}