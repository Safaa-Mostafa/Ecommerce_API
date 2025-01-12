using Application.DTOs.Product;
using Application.Modules.Products.Commands;
using Application.Modules.Products.Queries;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductCommand addProductDto);
        Task<Product> UpdateProduct(UpdateProductCommand product);
        Task<ReadProduct> GetProductById(GetProductByIdQuery query);
        Task<List<ReadProduct>> GetAllProductsAsync(GetAllProductQuery query);
    }
}
