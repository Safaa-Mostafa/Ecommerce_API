using Application.DTOs.Category;
using Application.Interfaces;
using Application.Modules.Categories.Commands; // تأكد من إضافة الـ Command هنا
using Application.Modules.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("with-products")]
        public async Task<IActionResult> GetAllCategoriesWithProducts([FromQuery] GetAllCategoriesWithProducts query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // إضافة فئة جديدة
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryCommand categoryCommand) // تغيير query إلى Command
        {
            var response = await _mediator.Send(categoryCommand);
            return Ok(response);
        }
    }
}
