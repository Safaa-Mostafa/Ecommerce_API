using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.Modules.Categories.Commands;
using Application.Modules.Products.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, ReadProduct>().ReverseMap();
            CreateMap<Category, ReadCategory>().ReverseMap();

            CreateMap<AddProduct, Product>();
            CreateMap<AddProduct, CreateProductCommand>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<AddCategory, CreateCategoryCommand>();

        }
    }
}
