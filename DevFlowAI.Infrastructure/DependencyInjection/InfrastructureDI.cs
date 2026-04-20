using DevFlowAI.Domain.Interfaces;
using DevFlowAI.Infrastructure.Persistence;
using DevFlowAI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevFlowAI.Infrastructure.DependencyInjection;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}