using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Modules.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string name { get; set; }
        public string? description { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CreateProductCommandHandler(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        async Task<int> IRequestHandler<CreateCategoryCommand, int>.Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = await _categoryService.AddCategoryAsync(request);
            return category;
        }
    }
}