using Application.DTOs.Category;
using Application.Modules.Categories.Commands;
using Application.Modules.Categories.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll(GetAllCategoriesQuery query)
        {
            var categories = _mediator.Send(query);
            return Ok(categories);
        }
        [HttpGet("with-products")]
        public IActionResult GetALLCategoriesWithProducts(GetAllCategoriesWithProducts query)
        {
            var categories = _mediator.Send(query);
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult addCategory([FromBody] AddCategory addCategory)
        {
            var createProductCommand = _mapper.Map<CreateCategoryCommand>(addCategory);
            var categoryId = _mediator.Send(createProductCommand);
            return Ok(categoryId);
        }
    }
}
