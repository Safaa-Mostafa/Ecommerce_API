using Application.DTOs.Category;
using Application.Interfaces;
using Application.Modules.Categories.Commands;
using Application.Modules.Categories.Queries;
using AutoMapper;
using MediatR;

namespace Application.services
{
    public class CategoryService:ICategoryService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoryService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReadCategory>> GetAllCategoriesAsync(GetAllCategoriesQuery query)
        {
            return await _mediator.Send(query);
        }
        public async Task<IEnumerable<ReadCategory>> GetAllCategoriesAsyncWithProductsAsync(GetAllCategoriesWithProducts query)
        {
            return await _mediator.Send(query);
        }
        public async Task<string> AddCategoryAsync(AddCategory addCategoryDto)
        {
            var createProductCommand = _mapper.Map<CreateCategoryCommand>(addCategoryDto);
            return await _mediator.Send(createProductCommand);
        }
    }
}
