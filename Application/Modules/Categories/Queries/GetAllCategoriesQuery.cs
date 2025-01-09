using Application.DTOs.Category;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Modules.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<ReadCategory>> { }

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<ReadCategory>>
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        public GetAllCategoriesQueryHandler(IGenericRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;

        }

        public async Task<List<ReadCategory>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {

            var categories = await _categoryRepo.GetAllAsync();

            if (categories == null || !categories.Any())
            {
                throw new CategoryListotFoundException("No categories found in the database.");
            }

            var categoriesDto = _mapper.Map<List<ReadCategory>>(categories);

            return categoriesDto;
        }
    }
}

