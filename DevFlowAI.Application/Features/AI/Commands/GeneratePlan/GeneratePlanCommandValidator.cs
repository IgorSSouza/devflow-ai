using FluentValidation;

namespace DevFlowAI.Application.Features.AI.Commands.GeneratePlan;

public class GeneratePlanCommandValidator : AbstractValidator<GeneratePlanCommand>
{
    public GeneratePlanCommandValidator()
    {
        RuleFor(x => x.WorkspaceId)
            .NotEmpty().WithMessage("O workspaceId é obrigatório.");

        RuleFor(x => x.Goal)
            .NotEmpty().WithMessage("O objetivo é obrigatório.")
            .MinimumLength(10).WithMessage("O objetivo deve ter pelo menos 10 caracteres.")
            .MaximumLength(1000).WithMessage("O objetivo deve ter no máximo 1000 caracteres.");
    }
}