using DevFlowAI.Domain.Entities;
using DevFlowAI.Infrastructure.Repositories;
using DevFlowAI.Infrastructure.Tests.Persistence;
using FluentAssertions;

namespace DevFlowAI.Infrastructure.Tests.Repositories;

public class WorkspaceRepositoryTests
{
    [Fact]
    public async Task AddAsync_And_GetAllAsync_Should_Persist_And_Return_Workspace()
    {
        // Arrange
        await using var context = TestDbContextFactory.Create();
        var repository = new WorkspaceRepository(context);

        var workspace = new Workspace($"Workspace Teste {Guid.NewGuid()}");

        // Act
        await repository.AddAsync(workspace);
        var workspaces = await repository.GetAllAsync();

        // Assert
        workspaces.Should().Contain(x => x.Id == workspace.Id && x.Name == workspace.Name);
    }
}