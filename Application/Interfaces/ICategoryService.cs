using Application.DTOs.Category;
using Application.Modules.Categories.Queries;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<ReadCategory>> GetAllCategoriesAsync(GetAllCategoriesQuery query);
        Task<string> AddCategoryAsync(AddCategory addCategoryDto);
        Task<IEnumerable<ReadCategory>> GetAllCategoriesAsyncWithProductsAsync(GetAllCategoriesWithProducts query);

    }
}
