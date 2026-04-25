using DevFlowAI.Application.Features.AI.Services;
using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using MediatR;

namespace DevFlowAI.Application.Features.AI.Commands.GeneratePlan;

public class GeneratePlanHandler : IRequestHandler<GeneratePlanCommand, List<Guid>>
{
    private readonly IAiPlanGenerator _aiPlanGenerator;
    private readonly ITaskRepository _taskRepository;

    public GeneratePlanHandler(
        IAiPlanGenerator aiPlanGenerator,
        ITaskRepository taskRepository)
    {
        _aiPlanGenerator = aiPlanGenerator;
        _taskRepository = taskRepository;
    }

    public async Task<List<Guid>> Handle(
        GeneratePlanCommand request,
        CancellationToken cancellationToken)
    {
        var generatedTasks = await _aiPlanGenerator.GenerateTasksFromGoalAsync(
            request.Goal,
            cancellationToken);

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

        return createdTaskIds;
    }
}