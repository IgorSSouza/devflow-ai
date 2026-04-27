namespace DevFlowAI.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }
    public Guid WorkspaceId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool Completed { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    private TaskItem() { }

    public TaskItem(Guid workspaceId, string title, string description)
    {
        Id = Guid.NewGuid();
        WorkspaceId = workspaceId;
        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        Completed = false;
        CompletedAt = null;
    }

    public void Complete()
    {
        if (Completed)
            return;

        Completed = true;
        CompletedAt = DateTime.UtcNow;
    }
}