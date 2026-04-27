using DevFlowAI.Application.Features.AI.Commands.GeneratePlan;
using FluentValidation.TestHelper;

namespace DevFlowAI.Application.Tests.Validators;

public class GeneratePlanCommandValidatorTests
{
    private readonly GeneratePlanCommandValidator _validator = new();

    [Fact]
    public void Should_Have_Error_When_WorkspaceId_Is_Empty()
    {
        var command = new GeneratePlanCommand
        {
            WorkspaceId = Guid.Empty,
            Goal = "Quero aprender arquitetura .NET e Docker"
        };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.WorkspaceId);
    }

    [Fact]
    public void Should_Have_Error_When_Goal_Is_Empty()
    {
        var command = new GeneratePlanCommand
        {
            WorkspaceId = Guid.NewGuid(),
            Goal = string.Empty
        };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.Goal);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Command_Is_Valid()
    {
        var command = new GeneratePlanCommand
        {
            WorkspaceId = Guid.NewGuid(),
            Goal = "Quero aprender arquitetura .NET, Docker e mensageria com um plano progressivo"
        };

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }
}