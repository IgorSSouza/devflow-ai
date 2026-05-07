using DevFlowAI.Domain.Entities;
using DevFlowAI.Infrastructure.Repositories;
using DevFlowAI.Infrastructure.Tests.Persistence;
using FluentAssertions;

namespace DevFlowAI.Infrastructure.Tests.Repositories;

public class TaskRepositoryTests : IClassFixture<PostgresContainerFixture>
{
    private readonly PostgresContainerFixture _fixture;

    public TaskRepositoryTests(PostgresContainerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task AddAsync_And_GetByWorkspaceIdAsync_Should_Persist_And_Return_Task()
    {
        // Arrange
        await using var context = TestDbContextFactory.Create(_fixture.ConnectionString);
        await context.Database.EnsureCreatedAsync();
        await TestDatabaseCleaner.CleanAsync(context);

        var workspaceRepository = new WorkspaceRepository(context);
        var taskRepository = new TaskRepository(context);

        var workspace = new Workspace($"Workspace Task Test {Guid.NewGuid()}");
        await workspaceRepository.AddAsync(workspace);

        var task = new TaskItem(
            workspace.Id,
            "Estudar integração",
            "Validar persistência real da task");

        // Act
        await taskRepository.AddAsync(task);
        var tasks = await taskRepository.GetByWorkspaceIdAsync(workspace.Id);

        // Assert
        tasks.Should().Contain(x =>
            x.Id == task.Id &&
            x.WorkspaceId == workspace.Id &&
            x.Title == "Estudar integração");
    }

    [Fact]
    public async Task GetByIdAsync_Should_Return_Task_When_Task_Exists()
    {
        // Arrange
        await using var context = TestDbContextFactory.Create(_fixture.ConnectionString);
        await context.Database.EnsureCreatedAsync();
        await TestDatabaseCleaner.CleanAsync(context);

        var workspaceRepository = new WorkspaceRepository(context);
        var taskRepository = new TaskRepository(context);

        var workspace = new Workspace($"Workspace GetById Test {Guid.NewGuid()}");
        await workspaceRepository.AddAsync(workspace);

        var task = new TaskItem(
            workspace.Id,
            "Buscar por id",
            "Validar busca por id");

        await taskRepository.AddAsync(task);

        // Act
        var result = await taskRepository.GetByIdAsync(task.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(task.Id);
        result.Title.Should().Be("Buscar por id");
    }

    [Fact]
    public async Task UpdateAsync_Should_Persist_Completed_And_CompletedAt()
    {
        // Arrange
        await using var context = TestDbContextFactory.Create(_fixture.ConnectionString);
        await context.Database.EnsureCreatedAsync();
        await TestDatabaseCleaner.CleanAsync(context);

        var workspaceRepository = new WorkspaceRepository(context);
        var taskRepository = new TaskRepository(context);

        var workspace = new Workspace($"Workspace Update Test {Guid.NewGuid()}");
        await workspaceRepository.AddAsync(workspace);

        var task = new TaskItem(
            workspace.Id,
            "Concluir task",
            "Validar update real");

        await taskRepository.AddAsync(task);

        task.Complete();

        // Act
        await taskRepository.UpdateAsync(task);

        var updatedTask = await taskRepository.GetByIdAsync(task.Id);

        // Assert
        updatedTask.Should().NotBeNull();
        updatedTask!.Completed.Should().BeTrue();
        updatedTask.CompletedAt.Should().NotBeNull();
    }
}