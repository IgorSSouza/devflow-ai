using Microsoft.Extensions.DependencyInjection;

namespace DevFlowAI.Application.DependencyInjection;

public static class ApplicationDI
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // futuramente handlers, validators etc.
        return services;
    }
}