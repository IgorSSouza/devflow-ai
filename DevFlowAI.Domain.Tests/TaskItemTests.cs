using DevFlowAI.Domain.Entities;
using FluentAssertions;

namespace DevFlowAI.Domain.Tests.Entities;

public class TaskItemTests
{
    [Fact]
    public void Constructor_Should_Create_Task_With_Default_Values()
    {
        // Arrange
        var workspaceId = Guid.NewGuid();

        // Act
        var task = new TaskItem(workspaceId, "Estudar testes", "Aprender testes unitários");

        // Assert
        task.Id.Should().NotBeEmpty();
        task.WorkspaceId.Should().Be(workspaceId);
        task.Title.Should().Be("Estudar testes");
        task.Description.Should().Be("Aprender testes unitários");
        task.Completed.Should().BeFalse();
        task.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void Complete_Should_Mark_Task_As_Completed()
    {
        // Arrange
        var workspaceId = Guid.NewGuid();
        var task = new TaskItem(workspaceId, "Estudar domínio", "Entender comportamento da entidade");

        // Act
        task.Complete();

        // Assert
        task.Completed.Should().BeTrue();
    }
}