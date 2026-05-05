using DevFlowAI.Application.Features.AI.Services;
using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevFlowAI.Application.Features.AI.Commands.GeneratePlan;

public class GeneratePlanHandler : IRequestHandler<GeneratePlanCommand, List<Guid>>
{
    private readonly IAiPlanGenerator _aiPlanGenerator;
    private readonly ITaskRepository _taskRepository;
    private readonly ILogger<GeneratePlanHandler> _logger;

    public GeneratePlanHandler(
        IAiPlanGenerator aiPlanGenerator,
        ITaskRepository taskRepository,
        ILogger<GeneratePlanHandler> logger)
    {
        _aiPlanGenerator = aiPlanGenerator;
        _taskRepository = taskRepository;
        _logger = logger;
    }

    public async Task<List<Guid>> Handle(
        GeneratePlanCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Iniciando geração de plano para workspace {WorkspaceId} com objetivo {Goal}",
            request.WorkspaceId,
            request.Goal);

        var generatedTasks = await _aiPlanGenerator.GenerateTasksFromGoalAsync(
            request.Goal,
            cancellationToken);

        _logger.LogInformation(
            "Gerador de plano retornou {TaskCount} tarefas para workspace {WorkspaceId}",
            generatedTasks.Count,
            request.WorkspaceId);

        var createdTaskIds = new List<Guid>();

        foreach (var generatedTask in generatedTasks)
        {
            var task = new TaskItem(
                request.WorkspaceId,
                generatedTask.Title,
                generatedTask.Description);

            await _taskRepository.AddAsync(task);
            createdTaskIds.Add(task.Id);
        }

        _logger.LogInformation(
            "Plano persistido com sucesso para workspace {WorkspaceId}. {CreatedCount} tarefas criadas",
            request.WorkspaceId,
            createdTaskIds.Count);

        return createdTaskIds;
    }
}