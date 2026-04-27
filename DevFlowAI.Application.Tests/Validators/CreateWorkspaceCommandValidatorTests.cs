using DevFlowAI.Application.Features.Workspaces.Commands.CreateWorkspace;
using FluentValidation.TestHelper;

namespace DevFlowAI.Application.Tests.Validators;

public class CreateWorkspaceCommandValidatorTests
{
    private readonly CreateWorkspaceCommandValidator _validator = new();

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var command = new CreateWorkspaceCommand
        {
            Name = string.Empty
        };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Too_Short()
    {
        var command = new CreateWorkspaceCommand
        {
            Name = "ab"
        };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Name_Is_Valid()
    {
        var command = new CreateWorkspaceCommand
        {
            Name = "Workspace de Estudos"
        };

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }
}