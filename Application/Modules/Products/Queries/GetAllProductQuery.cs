using Application.DTOs.Product;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Modules.Products.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<ReadProduct>>
    {
        public GetAllProductQuery() { }

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ReadProduct>>
        {
            private readonly IGenericRepository<Product> _productRepo;
            private readonly IMapper _mapper;

            public GetAllProductQueryHandler(
                IGenericRepository<Product> productRepo,
                IMapper mapper)
            {
                _productRepo = productRepo;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ReadProduct>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepo.GetAllAsync();

                if (products == null || !products.Any())
                {
                    throw new ProductListNotFoundException("No products found.");
                }

                var productsDto = _mapper.Map<List<ReadProduct>>(products);

                return productsDto;
            }
        }
    }
}
