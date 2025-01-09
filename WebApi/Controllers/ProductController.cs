using Application.DTOs.Product;
using Application.Interfaces;
using Application.Modules.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] AddProduct addProductDto)
        {
            var response = await _productService.CreateProduct(addProductDto);
            return ApiResponse(true, response, "product created successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQuery query)
        {
            var response = await _productService.GetProductById(query);
            return ApiResponse(true, response, "fetched product successfully");
        }
    }
}
