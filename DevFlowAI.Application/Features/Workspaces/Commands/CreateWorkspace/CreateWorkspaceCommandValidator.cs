using FluentValidation;

namespace DevFlowAI.Application.Features.Workspaces.Commands.CreateWorkspace;

public class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
{
    public CreateWorkspaceCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do workspace é obrigatório.")
            .MinimumLength(3).WithMessage("O nome do workspace deve ter pelo menos 3 caracteres.")
            .MaximumLength(100).WithMessage("O nome do workspace deve ter no máximo 100 caracteres.");
    }
}