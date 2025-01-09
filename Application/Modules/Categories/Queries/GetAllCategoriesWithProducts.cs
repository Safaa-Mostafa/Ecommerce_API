using Application.DTOs.Category;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Application.Modules.Categories.Queries
{
    public class GetAllCategoriesWithProducts : IRequest<ApiResponse<List<ReadCategory>>> { }
    public class GetAllCategoriesWithProductsHandler : IRequestHandler<GetAllCategoriesWithProducts, ApiResponse<List<ReadCategory>>>
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllCategoriesWithProductsHandler> _logger;
        public GetAllCategoriesWithProductsHandler(IGenericRepository<Category> categoryRepo, IMapper mapper, ILogger<GetAllCategoriesWithProductsHandler> logger)
        {
            _categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ApiResponse<List<ReadCategory>>> Handle(GetAllCategoriesWithProducts request, CancellationToken cancellationToken)
        {
            try
            {
                var spec = new CategorySpecification();
                var categories = await _categoryRepo.GetAllAsyncWithIncludes(spec);
                if (categories == null || !categories.Any())
                {
                    return new ApiResponse<List<ReadCategory>>(false, "No categories found.");
                }
                var categoriesDto = _mapper.Map<List<ReadCategory>>(categories);
                return new ApiResponse<List<ReadCategory>>(true, "Data fetched successfully", categoriesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories with products.");
                return new ApiResponse<List<ReadCategory>>(false, "An error occurred while processing your request.");
            }
        }
    }
}
