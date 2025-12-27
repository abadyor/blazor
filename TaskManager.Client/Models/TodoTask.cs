namespace TaskManager.Client.Models;

/// <summary>
/// Represents a task/todo item in the application.
/// </summary>
public class TodoTask
{
    /// <summary>
    /// Unique identifier for the task.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Title of the task.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Optional detailed description of the task.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Whether the task has been completed.
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// When the task was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Optional due date for the task.
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// When the task was marked as completed (null if not completed).
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Priority level of the task.
    /// </summary>
    public Priority Priority { get; set; }

    /// <summary>
    /// List of category IDs assigned to this task.
    /// </summary>
    public List<Guid> CategoryIds { get; set; } = new();

    /// <summary>
    /// Creates a new task with a generated ID and current timestamp.
    /// </summary>
    public static TodoTask Create(string title, string description = "", Priority priority = Priority.Medium, DateTime? dueDate = null)
    {
        return new TodoTask
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Priority = priority,
            DueDate = dueDate,
            CreatedAt = DateTime.UtcNow,
            IsCompleted = false
        };
    }

    /// <summary>
    /// Marks the task as completed.
    /// </summary>
    public void Complete()
    {
        IsCompleted = true;
        CompletedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Marks the task as not completed.
    /// </summary>
    public void Uncomplete()
    {
        IsCompleted = false;
        CompletedAt = null;
    }

    /// <summary>
    /// Toggles the completion status of the task.
    /// </summary>
    public void ToggleCompletion()
    {
        if (IsCompleted)
            Uncomplete();
        else
            Complete();
    }

    /// <summary>
    /// Checks if the task is overdue (past due date and not completed).
    /// </summary>
    public bool IsOverdue => DueDate.HasValue && DueDate.Value.Date < DateTime.UtcNow.Date && !IsCompleted;

    /// <summary>
    /// Checks if the task is due today.
    /// </summary>
    public bool IsDueToday => DueDate.HasValue && DueDate.Value.Date == DateTime.UtcNow.Date && !IsCompleted;

    /// <summary>
    /// Checks if the task is due within the next 3 days.
    /// </summary>
    public bool IsDueSoon => DueDate.HasValue && 
                             DueDate.Value.Date > DateTime.UtcNow.Date && 
                             DueDate.Value.Date <= DateTime.UtcNow.Date.AddDays(3) && 
                             !IsCompleted;
}
