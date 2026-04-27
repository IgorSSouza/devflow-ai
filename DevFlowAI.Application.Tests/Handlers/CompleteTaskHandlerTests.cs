using DevFlowAI.Application.Features.Tasks.Commands.CompleteTask;
using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace DevFlowAI.Application.Tests.Handlers;

public class CompleteTaskHandlerTests
{
    private readonly Mock<ITaskRepository> _taskRepositoryMock;
    private readonly CompleteTaskHandler _handler;

    public CompleteTaskHandlerTests()
    {
        _taskRepositoryMock = new Mock<ITaskRepository>();
        _handler = new CompleteTaskHandler(_taskRepositoryMock.Object);
    }

    [Fact]
    public async Task Should_Complete_Task_When_Task_Exists()
    {
        // Arrange
        var task = new TaskItem(Guid.NewGuid(), "Estudar handlers", "Aprender testes de aplicação");
        var command = new CompleteTaskCommand(task.Id);

        _taskRepositoryMock
            .Setup(x => x.GetByIdAsync(task.Id))
            .ReturnsAsync(task);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        task.Completed.Should().BeTrue();

        _taskRepositoryMock.Verify(x => x.UpdateAsync(task), Times.Once);
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Task_Does_Not_Exist()
    {
        // Arrange
        var command = new CompleteTaskCommand(Guid.NewGuid());

        _taskRepositoryMock
            .Setup(x => x.GetByIdAsync(command.TaskId))
            .ReturnsAsync((TaskItem?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Tarefa não encontrada.");

        _taskRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<TaskItem>()), Times.Never);
    }
}