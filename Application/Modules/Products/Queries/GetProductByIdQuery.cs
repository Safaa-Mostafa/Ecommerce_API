using Application.DTOs.Product;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Modules.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ReadProduct>
    {
        public int Id { get; set; }

    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ReadProduct>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ReadProduct> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
         var product = await _productService.GetProductById(request);
         return product;
        }
    }
}
