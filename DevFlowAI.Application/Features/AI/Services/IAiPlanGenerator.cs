using DevFlowAI.Application.Features.AI.DTOs;

namespace DevFlowAI.Application.Features.AI.Services;

public interface IAiPlanGenerator
{
    Task<List<GeneratedTaskDto>> GenerateTasksFromGoalAsync(string goal, CancellationToken cancellationToken);
}