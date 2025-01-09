using Application.DTOs.Category;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Modules.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<ApiResponse<List<ReadCategory>>> { }

    //public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ApiResponse<List<ReadCategory>>>
    //{
    //    private readonly IGenericRepository<Category> _categoryRepo;
    //    private readonly IMapper _mapper;
    //    private readonly ILogger<GetAllCategoriesQueryHandler> _logger;
    //    public GetAllCategoriesQueryHandler(IGenericRepository<Category> categoryRepo, IMapper mapper, ILogger<GetAllCategoriesQueryHandler> logger)
    //    {
    //        _categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
    //        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    //        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    //    }

    //    //public async Task<ApiResponse<List<ReadCategory>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    //    //{
    //        //try
    //        //{
    //        //    var categories = await _categoryRepo.GetAllAsync();

    //        //    if (categories == null || !categories.Any())
    //        //    {
    //        //        _logger.LogWarning("No categories found in the database.");
    //        //        return new ApiResponse<List<ReadCategory>>(new List<ReadCategory>());
    //        //    }

    //        //    var categoriesDto = _mapper.Map<List<ReadCategory>>(categories);

    //        //    return new ApiResponse<List<ReadCategory>>(categoriesDto, "Data Fetched successfully");
    //        //}
    //        //catch (Exception ex)
    //        //{
    //        //    _logger.LogError(ex, "An error occurred while retrieving categories.");
    //        //    throw;
    //        //}
    //    //}
    //}
}

