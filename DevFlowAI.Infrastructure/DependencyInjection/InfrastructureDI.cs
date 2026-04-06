using DevFlowAI.Domain.Interfaces;
using DevFlowAI.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevFlowAI.Infrastructure.DependencyInjection;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IWorkspaceRepository, InMemoryWorkspaceRepository>();

        return services;
    }
}