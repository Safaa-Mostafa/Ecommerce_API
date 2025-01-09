using Application.DTOs.Product;
using Application.Modules.Products.Commands;
using Application.Modules.Products.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] AddProduct addProductDto)
        {
            var command = _mapper.Map<CreateProductCommand>(addProductDto);
            var productId = await _mediator.Send(command);
            return HandleDataResponse(productId);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] GetProductByIdQuery query)
        {
            var product = _mediator.Send(query);
            return HandleDataResponse(product);
        }
    }
}
