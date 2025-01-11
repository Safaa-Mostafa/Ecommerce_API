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
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<List<ReadCategory>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(request);
            return categories.ToList();
        }
    }
}

