using Blazored.LocalStorage;
using TaskManager.Client.Models;

namespace TaskManager.Client.Services;

/// <summary>
/// Service for managing categories with local storage persistence.
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "taskmanager_categories";

    public CategoryService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _localStorage.GetItemAsync<List<Category>>(StorageKey) ?? new List<Category>();
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
    {
        var categories = await GetAllCategoriesAsync();
        return categories.FirstOrDefault(c => c.Id == id);
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        var categories = await GetAllCategoriesAsync();
        
        // Ensure ID is set
        if (category.Id == Guid.Empty)
            category.Id = Guid.NewGuid();
        
        categories.Add(category);
        await SaveCategoriesAsync(categories);
        
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        var categories = await GetAllCategoriesAsync();
        var index = categories.FindIndex(c => c.Id == category.Id);
        
        if (index >= 0)
        {
            categories[index] = category;
            await SaveCategoriesAsync(categories);
        }
        
        return category;
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        var categories = await GetAllCategoriesAsync();
        categories.RemoveAll(c => c.Id == id);
        await SaveCategoriesAsync(categories);
    }

    public async Task<List<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> ids)
    {
        var categories = await GetAllCategoriesAsync();
        var idSet = ids.ToHashSet();
        return categories.Where(c => idSet.Contains(c.Id)).ToList();
    }

    public async Task InitializeDefaultCategoriesAsync()
    {
        var categories = await GetAllCategoriesAsync();
        
        if (categories.Count == 0)
        {
            var defaultCategories = new List<Category>
            {
                Category.Create("Work", "#3498db"),
                Category.Create("Personal", "#9b59b6"),
                Category.Create("Shopping", "#2ecc71"),
                Category.Create("Health", "#e74c3c"),
                Category.Create("Finance", "#f39c12")
            };
            
            await SaveCategoriesAsync(defaultCategories);
        }
    }

    private async Task SaveCategoriesAsync(List<Category> categories)
    {
        await _localStorage.SetItemAsync(StorageKey, categories);
    }
}
