
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Modules.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<string>
    {
        public string name { get; set; }
        public string? description { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateCategoryCommand, string>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IGenericRepository<Category> categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork;
        }

        async Task<string> IRequestHandler<CreateCategoryCommand, string>.Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = _mapper.Map<Category>(request);
            await _categoryRepository.AddAsync(Category);
            await _unitOfWork.SaveChangesAsync();
            return Category.Id;
        }
    }
}