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
        private readonly ICategoryService _categoryService;

        public GetAllCategoriesWithProductsHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<ReadCategory>> Handle(GetAllCategoriesWithProducts request, CancellationToken cancellationToken)
        {
           var categories =  await _categoryService.GetAllCategoriesAsyncWithProductsAsync(request);
           return categories.ToList();
        }
    }
}
