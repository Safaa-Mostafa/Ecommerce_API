using Application.DTOs.Product;
using Application.Modules.Products.Queries;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<string> CreateProduct(AddProduct addProductDto);
        Task<ReadProduct> GetProductById(GetProductByIdQuery query);
    }
}
