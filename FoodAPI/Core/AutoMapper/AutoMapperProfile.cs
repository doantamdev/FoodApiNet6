using AutoMapper;
using Core.Models;
using Core.ViewModels.Categories;
using Core.ViewModels.Category;
using Core.ViewModels.Products;

namespace Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CategoryCreateVM, Category>();
            CreateMap<CategoryEditVM, CategoryVM>(); 
            CreateMap<CategoryEditVM, Category>();
            CreateMap<Category, CategoryVM>();

            
            CreateMap<ProductCreateVM, Products>();
            CreateMap<ProductEditVM, ProductsVM>();
            CreateMap<ProductEditVM, Products>();
            CreateMap<Products, ProductsVM>();
        }
    }
}
