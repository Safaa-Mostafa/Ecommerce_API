using Application.DTOs.Product;
using Application.Exceptions;
using Application.Interfaces;
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
            _productRepo = _unitOfWork.GetRepository<Product>(); // الحصول على الريبو الخاص بـ Product
            _mapper = mapper;
        }

        public async Task<string> CreateProduct(AddProduct addProductDto)
        {
            var product = _mapper.Map<Product>(addProductDto);
            await _productRepo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return product.Id;
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
    }
}
