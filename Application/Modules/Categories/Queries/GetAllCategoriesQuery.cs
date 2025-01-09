using Application.DTOs.Category;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Modules.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<ReadCategory>> { }

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<ReadCategory>>
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllCategoriesQueryHandler> _logger;
        public GetAllCategoriesQueryHandler(IGenericRepository<Category> categoryRepo, IMapper mapper, ILogger<GetAllCategoriesQueryHandler> logger)
        {
            _categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        public async Task<List<ReadCategory>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {

            var categories = await _categoryRepo.GetAllAsync();

            if (categories == null || !categories.Any())
            {
                _logger.LogWarning("No categories found in the database.");
                return new List<ReadCategory>();
            }

            var categoriesDto = _mapper.Map<List<ReadCategory>>(categories);

            return categoriesDto;
        }
    }
}

