namespace Tempo.Core.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime? CompletedAt { get; set; }
    public int Order { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public bool IsCompleted => CompletedAt.HasValue;
}
