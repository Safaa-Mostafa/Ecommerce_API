using Application.DTOs.Category;
using Application.Exceptions;
using Application.Interfaces;
using Application.Modules.Categories.Commands;
using Application.Modules.Categories.Queries;
using Application.Specifications;
using AutoMapper;
using Domain.Entities;

namespace Application.services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepo = _unitOfWork.GetRepository<Category>(); // الحصول على الريبو الخاص بـ Product
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReadCategory>> GetAllCategoriesAsync(GetAllCategoriesQuery query)
        {
            var categories = await _categoryRepo.GetAllAsync();
            var categoriesDto = _mapper.Map<List<ReadCategory>>(categories);
            return categoriesDto;
        }
        public async Task<IEnumerable<ReadCategory>> GetAllCategoriesAsyncWithProductsAsync(GetAllCategoriesWithProducts query)
        {
            var spec = new CategorySpecification();
            var categories = await _categoryRepo.GetAllAsyncWithIncludes(spec);
            var categoriesDto = _mapper.Map<List<ReadCategory>>(categories);
            return categoriesDto;
        }

        public async Task<int> AddCategoryAsync(CreateCategoryCommand addCategoryDto)
        {
            var category = _mapper.Map<Category>(addCategoryDto);
            var newCategory = _categoryRepo.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return newCategory.Id;
        }
    }
}
