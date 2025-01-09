using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Modules.Products.Commands
{
    public class CreateProductCommand : IRequest<ApiResponse<string>>
    {
        public string? Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryId { get; set; }
        public Discount discount { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<string>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IGenericRepository<Product> productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return new ApiResponse<string>(true, "Product added success", product.Id);
        }
    }
}
