using DevFlowAI.Application.Features.Tasks.Commands.CreateTask;
using FluentValidation.TestHelper;

namespace DevFlowAI.Application.Tests.Validators;

public class CreateTaskCommandValidatorTests
{
    private readonly CreateTaskCommandValidator _validator = new();

    [Fact]
    public void Should_Have_Error_When_WorkspaceId_Is_Empty()
    {
        var command = new CreateTaskCommand
        {
            WorkspaceId = Guid.Empty,
            Title = "Estudar testes",
            Description = "Aprender validação"
        };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.WorkspaceId);
    }

    [Fact]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        var command = new CreateTaskCommand
        {
            WorkspaceId = Guid.NewGuid(),
            Title = string.Empty,
            Description = "Aprender validação"
        };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Command_Is_Valid()
    {
        var command = new CreateTaskCommand
        {
            WorkspaceId = Guid.NewGuid(),
            Title = "Estudar testes",
            Description = "Aprender validação"
        };

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }
}