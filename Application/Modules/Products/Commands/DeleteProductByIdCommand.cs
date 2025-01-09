
using Application.Wrappers;
using MediatR;

namespace Application.Modules.Products.Commands
{
    public class DeleteProductByIdCommand: IRequest<ApiResponse<string>>
    {
        public string ProductId { get; set; }

    }
}
