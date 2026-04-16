using FluentValidation;

namespace DevFlowAI.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.WorkspaceId)
            .NotEmpty().WithMessage("O workspaceId é obrigatório.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título da tarefa é obrigatório.")
            .MinimumLength(3).WithMessage("O título da tarefa deve ter pelo menos 3 caracteres.")
            .MaximumLength(100).WithMessage("O título da tarefa deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição da tarefa é obrigatória.")
            .MaximumLength(500).WithMessage("A descrição da tarefa deve ter no máximo 500 caracteres.");
    }
}