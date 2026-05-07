using DevFlowAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFlowAI.Infrastructure.Tests.Persistence;

public static class TestDbContextFactory
{
    public static AppDbContext Create(string connectionString)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new AppDbContext(options);
    }
}