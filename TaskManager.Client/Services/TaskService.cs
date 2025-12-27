using Blazored.LocalStorage;
using TaskManager.Client.Models;

namespace TaskManager.Client.Services;

/// <summary>
/// Service for managing tasks with local storage persistence.
/// </summary>
public class TaskService : ITaskService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "taskmanager_tasks";

    public TaskService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<TodoTask>> GetAllTasksAsync()
    {
        return await _localStorage.GetItemAsync<List<TodoTask>>(StorageKey) ?? new List<TodoTask>();
    }

    public async Task<TodoTask?> GetTaskByIdAsync(Guid id)
    {
        var tasks = await GetAllTasksAsync();
        return tasks.FirstOrDefault(t => t.Id == id);
    }

    public async Task<TodoTask> CreateTaskAsync(TodoTask task)
    {
        var tasks = await GetAllTasksAsync();
        
        // Ensure ID and creation time are set
        if (task.Id == Guid.Empty)
            task.Id = Guid.NewGuid();
        
        if (task.CreatedAt == default)
            task.CreatedAt = DateTime.UtcNow;
        
        tasks.Add(task);
        await SaveTasksAsync(tasks);
        
        return task;
    }

    public async Task<TodoTask> UpdateTaskAsync(TodoTask task)
    {
        var tasks = await GetAllTasksAsync();
        var index = tasks.FindIndex(t => t.Id == task.Id);
        
        if (index >= 0)
        {
            tasks[index] = task;
            await SaveTasksAsync(tasks);
        }
        
        return task;
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        var tasks = await GetAllTasksAsync();
        tasks.RemoveAll(t => t.Id == id);
        await SaveTasksAsync(tasks);
    }

    public async Task<List<TodoTask>> GetFilteredTasksAsync(TaskFilter filter)
    {
        var tasks = await GetAllTasksAsync();
        return filter.Apply(tasks).OrderByDescending(t => t.Priority)
                                  .ThenBy(t => t.DueDate ?? DateTime.MaxValue)
                                  .ThenByDescending(t => t.CreatedAt)
                                  .ToList();
    }

    public async Task<TodoTask?> ToggleTaskCompletionAsync(Guid id)
    {
        var tasks = await GetAllTasksAsync();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        
        if (task != null)
        {
            task.ToggleCompletion();
            await SaveTasksAsync(tasks);
        }
        
        return task;
    }

    public async Task<TaskStats> GetTaskStatsAsync()
    {
        var tasks = await GetAllTasksAsync();
        
        return new TaskStats
        {
            TotalTasks = tasks.Count,
            CompletedTasks = tasks.Count(t => t.IsCompleted),
            PendingTasks = tasks.Count(t => !t.IsCompleted),
            OverdueTasks = tasks.Count(t => t.IsOverdue),
            DueTodayTasks = tasks.Count(t => t.IsDueToday)
        };
    }

    private async Task SaveTasksAsync(List<TodoTask> tasks)
    {
        await _localStorage.SetItemAsync(StorageKey, tasks);
    }
}
