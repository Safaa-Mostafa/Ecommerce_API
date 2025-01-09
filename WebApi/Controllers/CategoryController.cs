using Application.DTOs.Category;
using Application.Interfaces;
using Application.Modules.Categories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query)
        {
            var response = await _categoryService.GetAllCategoriesAsync(query);
            return ApiResponse(true, response, "All categories fetched successfully");
        }

        [HttpGet("with-products")]
        public async Task<IActionResult> GetAllCategoriesWithProducts([FromQuery] GetAllCategoriesWithProducts query)
        {
            var response = await _categoryService.GetAllCategoriesAsyncWithProductsAsync(query);
            return ApiResponse(true, response, "All categories fetched successfully");
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategory categoryDto)
        {
            var response = await _categoryService.AddCategoryAsync(categoryDto);
            return ApiResponse(true,response,"Added category successfully");
        }
    }
}
