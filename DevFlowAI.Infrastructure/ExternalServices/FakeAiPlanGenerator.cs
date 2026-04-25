using DevFlowAI.Application.Features.AI.DTOs;
using DevFlowAI.Application.Features.AI.Services;

namespace DevFlowAI.Infrastructure.ExternalServices;

public class FakeAiPlanGenerator : IAiPlanGenerator
{
    public Task<List<GeneratedTaskDto>> GenerateTasksFromGoalAsync(string goal, CancellationToken cancellationToken)
    {
        var tasks = new List<GeneratedTaskDto>
        {
            new GeneratedTaskDto
            {
                Title = "Entender o objetivo",
                Description = $"Analisar o objetivo informado: {goal}"
            },
            new GeneratedTaskDto
            {
                Title = "Quebrar em etapas",
                Description = "Dividir o objetivo em tarefas menores e executáveis"
            },
            new GeneratedTaskDto
            {
                Title = "Executar a primeira etapa",
                Description = "Começar pela tarefa de maior impacto inicial"
            }
        };

        return Task.FromResult(tasks);
    }
}