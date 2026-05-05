using DevFlowAI.Infrastructure.Persistence;

namespace DevFlowAI.Infrastructure.Tests.Persistence;

public static class TestDatabaseCleaner
{
    public static async Task CleanAsync(AppDbContext context)
    {
        context.Tasks.RemoveRange(context.Tasks);
        context.Workspaces.RemoveRange(context.Workspaces);

        await context.SaveChangesAsync();
    }
}