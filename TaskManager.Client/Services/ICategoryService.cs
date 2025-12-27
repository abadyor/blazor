using TaskManager.Client.Models;

namespace TaskManager.Client.Services;

/// <summary>
/// Service interface for managing categories.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Gets all categories.
    /// </summary>
    Task<List<Category>> GetAllCategoriesAsync();

    /// <summary>
    /// Gets a specific category by ID.
    /// </summary>
    Task<Category?> GetCategoryByIdAsync(Guid id);

    /// <summary>
    /// Creates a new category.
    /// </summary>
    Task<Category> CreateCategoryAsync(Category category);

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    Task<Category> UpdateCategoryAsync(Category category);

    /// <summary>
    /// Deletes a category by ID.
    /// </summary>
    Task DeleteCategoryAsync(Guid id);

    /// <summary>
    /// Gets multiple categories by their IDs.
    /// </summary>
    Task<List<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> ids);

    /// <summary>
    /// Initializes default categories if none exist.
    /// </summary>
    Task InitializeDefaultCategoriesAsync();
}
