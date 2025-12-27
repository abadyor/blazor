namespace TaskManager.Client.Models;

/// <summary>
/// Represents filter criteria for querying tasks.
/// </summary>
public class TaskFilter
{
    /// <summary>
    /// Text to search for in task title and description.
    /// </summary>
    public string? SearchTerm { get; set; }

    /// <summary>
    /// Filter by completion status. Null means show all.
    /// </summary>
    public bool? IsCompleted { get; set; }

    /// <summary>
    /// Filter by priority level. Null means show all priorities.
    /// </summary>
    public Priority? Priority { get; set; }

    /// <summary>
    /// Filter by category. Null means show all categories.
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// Show only tasks due before this date.
    /// </summary>
    public DateTime? DueBefore { get; set; }

    /// <summary>
    /// Show only tasks due after this date.
    /// </summary>
    public DateTime? DueAfter { get; set; }

    /// <summary>
    /// Show only overdue tasks.
    /// </summary>
    public bool ShowOverdueOnly { get; set; }

    /// <summary>
    /// Show only tasks due today.
    /// </summary>
    public bool ShowDueTodayOnly { get; set; }

    /// <summary>
    /// Applies the filter to a collection of tasks.
    /// </summary>
    public IEnumerable<TodoTask> Apply(IEnumerable<TodoTask> tasks)
    {
        var result = tasks;

        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            var term = SearchTerm.ToLowerInvariant();
            result = result.Where(t =>
                t.Title.ToLowerInvariant().Contains(term) ||
                t.Description.ToLowerInvariant().Contains(term));
        }

        if (IsCompleted.HasValue)
        {
            result = result.Where(t => t.IsCompleted == IsCompleted.Value);
        }

        if (Priority.HasValue)
        {
            result = result.Where(t => t.Priority == Priority.Value);
        }

        if (CategoryId.HasValue)
        {
            result = result.Where(t => t.CategoryIds.Contains(CategoryId.Value));
        }

        if (DueBefore.HasValue)
        {
            result = result.Where(t => t.DueDate.HasValue && t.DueDate.Value.Date <= DueBefore.Value.Date);
        }

        if (DueAfter.HasValue)
        {
            result = result.Where(t => t.DueDate.HasValue && t.DueDate.Value.Date >= DueAfter.Value.Date);
        }

        if (ShowOverdueOnly)
        {
            result = result.Where(t => t.IsOverdue);
        }

        if (ShowDueTodayOnly)
        {
            result = result.Where(t => t.IsDueToday);
        }

        return result;
    }

    /// <summary>
    /// Resets all filter criteria to their default values.
    /// </summary>
    public void Reset()
    {
        SearchTerm = null;
        IsCompleted = null;
        Priority = null;
        CategoryId = null;
        DueBefore = null;
        DueAfter = null;
        ShowOverdueOnly = false;
        ShowDueTodayOnly = false;
    }

    /// <summary>
    /// Checks if any filter criteria is set.
    /// </summary>
    public bool HasActiveFilters =>
        !string.IsNullOrWhiteSpace(SearchTerm) ||
        IsCompleted.HasValue ||
        Priority.HasValue ||
        CategoryId.HasValue ||
        DueBefore.HasValue ||
        DueAfter.HasValue ||
        ShowOverdueOnly ||
        ShowDueTodayOnly;
}
