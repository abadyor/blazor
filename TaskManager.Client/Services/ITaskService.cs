using TaskManager.Client.Models;

namespace TaskManager.Client.Services;

/// <summary>
/// Service interface for managing tasks.
/// </summary>
public interface ITaskService
{
    /// <summary>
    /// Gets all tasks.
    /// </summary>
    Task<List<TodoTask>> GetAllTasksAsync();

    /// <summary>
    /// Gets a specific task by ID.
    /// </summary>
    Task<TodoTask?> GetTaskByIdAsync(Guid id);

    /// <summary>
    /// Creates a new task.
    /// </summary>
    Task<TodoTask> CreateTaskAsync(TodoTask task);

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    Task<TodoTask> UpdateTaskAsync(TodoTask task);

    /// <summary>
    /// Deletes a task by ID.
    /// </summary>
    Task DeleteTaskAsync(Guid id);

    /// <summary>
    /// Gets tasks matching the specified filter criteria.
    /// </summary>
    Task<List<TodoTask>> GetFilteredTasksAsync(TaskFilter filter);

    /// <summary>
    /// Toggles the completion status of a task.
    /// </summary>
    Task<TodoTask?> ToggleTaskCompletionAsync(Guid id);

    /// <summary>
    /// Gets count statistics for tasks.
    /// </summary>
    Task<TaskStats> GetTaskStatsAsync();
}

/// <summary>
/// Statistics about tasks in the system.
/// </summary>
public class TaskStats
{
    public int TotalTasks { get; set; }
    public int CompletedTasks { get; set; }
    public int PendingTasks { get; set; }
    public int OverdueTasks { get; set; }
    public int DueTodayTasks { get; set; }
}
