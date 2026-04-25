using MediatR;

namespace DevFlowAI.Application.Features.Tasks.Commands.CompleteTask;

public class CompleteTaskCommand : IRequest
{
    public Guid TaskId { get; set; }

    public CompleteTaskCommand(Guid taskId)
    {
        TaskId = taskId;
    }
}