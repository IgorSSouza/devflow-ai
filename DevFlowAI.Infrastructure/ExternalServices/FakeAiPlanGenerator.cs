using DevFlowAI.Application.Features.AI.DTOs;
using DevFlowAI.Application.Features.AI.Services;

namespace DevFlowAI.Infrastructure.ExternalServices;

public class FakeAiPlanGenerator : IAiPlanGenerator
{
    public Task<List<GeneratedTaskDto>> GenerateTasksFromGoalAsync(string goal, CancellationToken cancellationToken)
    {
        var normalizedGoal = goal.ToLowerInvariant();
        var tasks = new List<GeneratedTaskDto>();

        tasks.Add(new GeneratedTaskDto
        {
            Title = "Entender o objetivo",
            Description = $"Analisar o objetivo informado e definir um plano inicial para: {goal}"
        });

        if (normalizedGoal.Contains("arquitetura"))
        {
            tasks.Add(new GeneratedTaskDto
            {
                Title = "Estudar fundamentos de arquitetura",
                Description = "Revisar separação de camadas, responsabilidades e dependências da aplicação"
            });
        }

        if (normalizedGoal.Contains("docker"))
        {
            tasks.Add(new GeneratedTaskDto
            {
                Title = "Praticar Docker no projeto",
                Description = "Subir API e banco em containers e revisar Dockerfile e docker-compose"
            });
        }

        if (normalizedGoal.Contains("mensageria"))
        {
            tasks.Add(new GeneratedTaskDto
            {
                Title = "Pesquisar fluxo assíncrono",
                Description = "Entender onde mensageria pode entrar no sistema para desacoplar processamento"
            });
        }

        if (normalizedGoal.Contains("frontend"))
        {
            tasks.Add(new GeneratedTaskDto
            {
                Title = "Planejar interface do usuário",
                Description = "Definir a tela inicial do sistema e como exibir workspaces e tasks"
            });
        }

        if (normalizedGoal.Contains("teste") || normalizedGoal.Contains("testes"))
        {
            tasks.Add(new GeneratedTaskDto
            {
                Title = "Criar estratégia de testes",
                Description = "Planejar testes de domínio, handlers e validações principais do sistema"
            });
        }

        if (tasks.Count == 1)
        {
            tasks.Add(new GeneratedTaskDto
            {
                Title = "Quebrar o objetivo em etapas",
                Description = "Dividir o objetivo em pequenas tarefas executáveis"
            });

            tasks.Add(new GeneratedTaskDto
            {
                Title = "Executar a primeira etapa",
                Description = "Começar pela tarefa mais simples e de maior impacto inicial"
            });
        }

        return Task.FromResult(tasks);
    }
}