using Application.DTOs.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using Xunit;

namespace Application.Tests.Controllers
{
    public class ProductControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ProductController _controller;

        public ProductControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ProductController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateProduct_ReturnsOkResult_WithExpectedResponse()
        {
            var addProduct = new AddProduct { Name = "Test Product", Price = 100.0M, StockQuantity = 10, CategoryId ="1"};
            

            var expectedResponse = 1;
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<AddProduct>(), default))
                .ReturnsAsync(expectedResponse);

            var result = await _controller.CreateProduct(addProduct);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResponse, okResult.Value);
            _mediatorMock.Verify(m => m.Send(It.IsAny<AddProduct>(), default), Times.Once);
        }
    }
}
