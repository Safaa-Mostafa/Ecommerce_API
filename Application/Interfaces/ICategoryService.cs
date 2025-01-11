using Application.DTOs.Category;
using Application.Modules.Categories.Commands;
using Application.Modules.Categories.Queries;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<ReadCategory>> GetAllCategoriesAsync(GetAllCategoriesQuery query);
        Task<int> AddCategoryAsync(CreateCategoryCommand addCategoryDto);
        Task<IEnumerable<ReadCategory>> GetAllCategoriesAsyncWithProductsAsync(GetAllCategoriesWithProducts query);

    }
}
