using Application.DTOs.Product;
using Application.Exceptions;
using Application.Interfaces;
using Application.Modules.Products.Commands;
using Application.Modules.Products.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepo = _unitOfWork.GetRepository<Product>();
            _mapper = mapper;
        }

        public async Task<int> CreateProduct(CreateProductCommand request)
        {
            var product = _mapper.Map<Product>(request);
            var newProduct = _productRepo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return newProduct.Id;
        }
        public async Task<ReadProduct> GetProductById(GetProductByIdQuery query)
        {
            var product = await _productRepo.GetByIdAsync(query.Id);
            var prodctDto = _mapper.Map<ReadProduct>(product);
            return prodctDto;
        }
        public async Task<List<ReadProduct>> GetAllProductsAsync(GetAllProductQuery query)
        {
            var products = await _productRepo.GetAllAsync();
            return _mapper.Map<List<ReadProduct>>(products);
        }
        public async Task<Product> UpdateProduct(UpdateProductCommand request)
        {
            var updatedProduct = _mapper.Map<Product>(request);
            var product = await _productRepo.GetByIdAsync(updatedProduct.Id);
            if( product is null)throw new ProductNotFoundException($"Product with ID {updatedProduct.Id} not found.");
            _mapper.Map(updatedProduct, product);
            _productRepo.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return product;
        }

    }
}
