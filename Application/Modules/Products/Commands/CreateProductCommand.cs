using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Modules.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string? Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryId { get; set; }
        public Discount discount { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,int>
    {
        private readonly IProductService _productService;
        public CreateProductCommandHandler( IMapper mapper, IProductService productService)
        {
            _productService = productService ;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
           var result  =await _productService.CreateProduct(request);
            return result;
        }
    }
}
