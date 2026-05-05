using DevFlowAI.Application.Features.AI.Commands.GeneratePlan;
using DevFlowAI.Application.Features.AI.DTOs;
using DevFlowAI.Application.Features.AI.Services;
using DevFlowAI.Domain.Entities;
using DevFlowAI.Domain.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace DevFlowAI.Application.Tests.Handlers;

public class GeneratePlanHandlerTests
{
    private readonly Mock<IAiPlanGenerator> _aiPlanGeneratorMock;
    private readonly Mock<ITaskRepository> _taskRepositoryMock;
    private readonly Mock<ILogger<GeneratePlanHandler>> _loggerMock;
    private readonly GeneratePlanHandler _handler;

    public GeneratePlanHandlerTests()
    {
        _aiPlanGeneratorMock = new Mock<IAiPlanGenerator>();
        _taskRepositoryMock = new Mock<ITaskRepository>();
        _loggerMock = new Mock<ILogger<GeneratePlanHandler>>();

        _handler = new GeneratePlanHandler(
            _aiPlanGeneratorMock.Object,
            _taskRepositoryMock.Object,
            _loggerMock.Object);
    }

    [Fact]
    public async Task Should_Generate_And_Save_Tasks_From_Goal()
    {
        var workspaceId = Guid.NewGuid();

        var command = new GeneratePlanCommand
        {
            WorkspaceId = workspaceId,
            Goal = "Quero aprender arquitetura .NET e Docker"
        };

        var generatedTasks = new List<GeneratedTaskDto>
        {
            new GeneratedTaskDto
            {
                Title = "Estudar arquitetura",
                Description = "Revisar camadas e responsabilidades"
            },
            new GeneratedTaskDto
            {
                Title = "Praticar Docker",
                Description = "Containerizar API e banco"
            }
        };

        _aiPlanGeneratorMock
            .Setup(x => x.GenerateTasksFromGoalAsync(command.Goal, It.IsAny<CancellationToken>()))
            .ReturnsAsync(generatedTasks);

        var savedTasks = new List<TaskItem>();

        _taskRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<TaskItem>()))
            .Callback<TaskItem>(task => savedTasks.Add(task))
            .Returns(Task.CompletedTask);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().HaveCount(2);
        savedTasks.Should().HaveCount(2);

        savedTasks[0].WorkspaceId.Should().Be(workspaceId);
        savedTasks[0].Title.Should().Be("Estudar arquitetura");
        savedTasks[0].Description.Should().Be("Revisar camadas e responsabilidades");

        savedTasks[1].WorkspaceId.Should().Be(workspaceId);
        savedTasks[1].Title.Should().Be("Praticar Docker");
        savedTasks[1].Description.Should().Be("Containerizar API e banco");

        _aiPlanGeneratorMock.Verify(
            x => x.GenerateTasksFromGoalAsync(command.Goal, It.IsAny<CancellationToken>()),
            Times.Once);

        _taskRepositoryMock.Verify(
            x => x.AddAsync(It.IsAny<TaskItem>()),
            Times.Exactly(2));
    }
}