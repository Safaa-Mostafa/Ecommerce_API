using Application.DTOs.Category;
using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Modules.Categories.Queries
{
    public class GetAllCategoriesWithProducts : IRequest<List<ReadCategory>> { }

    public class GetAllCategoriesWithProductsHandler : IRequestHandler<GetAllCategoriesWithProducts, List<ReadCategory>>
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public GetAllCategoriesWithProductsHandler(
            IGenericRepository<Category> categoryRepo,
            IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<List<ReadCategory>> Handle(GetAllCategoriesWithProducts request, CancellationToken cancellationToken)
        {
            var spec = new CategorySpecification();
            var categories = await _categoryRepo.GetAllAsyncWithIncludes(spec);
            if (categories == null || !categories.Any())
            {
                throw new CategoryListotFoundException("No categories found in the database.");
            }
            var categoriesDto = _mapper.Map<List<ReadCategory>>(categories);
            return categoriesDto;
        }
    }
}
