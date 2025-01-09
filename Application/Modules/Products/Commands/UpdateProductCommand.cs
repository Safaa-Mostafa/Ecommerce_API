using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Modules.Products.Commands
{
    public class UpdateProductCommand
    {
        public string? Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Discount discount { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<string>>
        {
            private readonly IGenericRepository<Product> _productRepository;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly Product _product;
            public UpdateProductCommandHandler(IGenericRepository<Product> productRepository, IMapper mapper, IUnitOfWork unitOfWork, Product product)
            {
                _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _unitOfWork = unitOfWork;
                _product = product;
            }

            public async Task<ApiResponse<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request);
                await _productRepository.UpdateAsync(product);
                await _unitOfWork.SaveChangesAsync();
                return new ApiResponse<string>(true, "Product updated successfully", product.Id);
            }
        }
    }
}

