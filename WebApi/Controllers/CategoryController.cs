using Application.DTOs.Category;
using Application.Interfaces;
using Application.Modules.Categories.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll(GetAllCategoriesQuery query)
        {
            var categories = _categoryService.GetAllCategoriesAsync(query);
            return HandleDataResponse(categories);
        }
        [HttpGet("with-products")]
        public IActionResult GetALLCategoriesWithProducts(GetAllCategoriesWithProducts query)
        {
            return HandleDataResponse(_categoryService);
        }
        [HttpPost]
        public IActionResult addCategory([FromBody] AddCategory addCategory)
        {
            var category = _categoryService.AddCategoryAsync(addCategory);
            return HandleDataResponse(_categoryService);
        }
    }
}
