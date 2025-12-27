namespace TaskManager.Client.Models;

/// <summary>
/// Represents a category that can be assigned to tasks.
/// </summary>
public class Category
{
    /// <summary>
    /// Unique identifier for the category.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Display name of the category.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Hex color code for the category badge (e.g., "#3498db").
    /// </summary>
    public string Color { get; set; } = "#6c757d";

    /// <summary>
    /// Creates a new category with a generated ID.
    /// </summary>
    public static Category Create(string name, string color = "#6c757d")
    {
        return new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            Color = color
        };
    }
}
