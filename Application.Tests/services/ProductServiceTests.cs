using Application.DTOs.Product;
using Application.Interfaces;
using Application.Modules.Products.Commands;
using AutoMapper;
using MediatR;
using Moq;
using Xunit;
namespace Application.Tests.services
{
    public class ProductServiceTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IProductService _productService;
        public ProductServiceTests(Mock<IMediator> mediator, Mock<IMapper> mapper)
        {
            _mediatorMock = mediator;
            _mapperMock = mapper;
        }
        public ProductServiceTests()
        {

        }
        [Fact]
        public async Task CreateProduct_ShouldReturnProductId_WhenProductIsCreated()
        {
            // Arrange
            var addProductDto = new AddProduct
            {
                Name = "Test Product",
                Description = "Description",
            };

            //var createProductCommand = new CreateProductCommand
            //{
            //    Name = addProductDto.Name,
            //    Description = addProductDto.Description
            //};
            //var expectedProductId = Guid.NewGuid().ToString();
            //_mapperMock.Setup(m => m.Map<CreateProductCommand>(addProductDto)).Returns(createProductCommand);
            //_mediatorMock.Setup(m => m.Send(createProductCommand, default)).ReturnsAsync(expectedProductId);

            //var result = await _productService.CreateProduct(addProductDto);

            //Assert.Equal(expectedProductId, result);
            //_mapperMock.Verify(m => m.Map<CreateProductCommand>(addProductDto), Times.Once);
            //_mediatorMock.Verify(m => m.Send(createProductCommand, default), Times.Once);


        }
    }
}
