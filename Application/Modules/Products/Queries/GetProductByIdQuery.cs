using Application.DTOs.Product;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Modules.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ApiResponse<ReadProduct>>
    {
        public string Id { get; set; }

        public GetProductByIdQuery(string id)
        {
            Id = id;
        }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ReadProduct>>
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ApiResponse<ReadProduct>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            var productDto = _mapper.Map<ReadProduct>(product);

            return new ApiResponse<ReadProduct>(true, "Data Fetched Successfully", productDto);
        }
    }
}
