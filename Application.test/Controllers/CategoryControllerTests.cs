using MediatR;
using Moq;
using WebApi.Controllers;

namespace Application.test.Controllers
{
    public class CategoryControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CategoryController _categoryController;

        public CategoryControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _categoryController = new CategoryController(_mediatorMock.Object);
        }
    }
}

