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
        public string Id { get; set; }

    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ReadProduct>
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ReadProduct> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ProductNotFoundException($" product with Id {request.Id} is not found ");
            }
            var productDto = _mapper.Map<ReadProduct>(product);
            return productDto;
        }
    }
}
