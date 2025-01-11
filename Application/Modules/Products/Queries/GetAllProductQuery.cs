using Application.DTOs.Product;
using Application.Interfaces;
using MediatR;

namespace Application.Modules.Products.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<ReadProduct>>
    {
        public GetAllProductQuery() { }

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ReadProduct>>
        {
            private readonly IProductService _productService;

            public GetAllProductQueryHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<IEnumerable<ReadProduct>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productService.GetAllProductsAsync(request);
                return products.ToList();
            }
        }
    }
}
