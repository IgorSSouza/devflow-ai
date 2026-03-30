namespace DevFlowAI.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool Completed { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private TaskItem() { }

    public TaskItem(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        Completed = false;
    }

    public void Complete()
    {
        Completed = true;
    }
}