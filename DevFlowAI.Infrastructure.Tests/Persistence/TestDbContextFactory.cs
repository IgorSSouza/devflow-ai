using DevFlowAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFlowAI.Infrastructure.Tests.Persistence;

public static class TestDbContextFactory
{
    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=devflowai;Username=devflow;Password=devflow123")
            .Options;

        return new AppDbContext(options);
    }
}