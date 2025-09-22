namespace Tempo.Core.Responses;

public class TaskResponse
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
    public int Order { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
