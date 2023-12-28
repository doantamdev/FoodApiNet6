using AutoMapper;
using Core.Configurations;
using Core.Models;
using Core.ViewModels.Categories;
using Core.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CategoryServices 
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryServices(ApplicationDBContext dBContext, IMapper mapper) 
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }
        public async Task<CategoryVM> Create(CategoryCreateVM model)
        {
            var newCategory = _mapper.Map<Category>(model);
            _dbContext.Categories!.Add(newCategory);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryVM>(newCategory);
        }
        public async Task<List<CategoryVM>> GetAll()
        {
            var categories = await _dbContext.Categories!.ToListAsync();
            return _mapper.Map<List<CategoryVM>>(categories);
        }

        public async Task<CategoryVM> GetByID(int categoryId)
        {
            var category = await _dbContext.Categories!.FirstOrDefaultAsync(c => c.ID == categoryId);
            return _mapper.Map<CategoryVM>(category);
        }

        public async Task<CategoryVM> Edit(int categoryId, CategoryEditVM model)
        {
            var category = await _dbContext.Categories!.FirstOrDefaultAsync(c => c.ID == categoryId);

            if (category == null)
            {
                new NotFoundResult();
            }
            else
            {
                category.ID = categoryId;
                category.Name = model.Name;
                category.Description = model.Description;
                await _dbContext.SaveChangesAsync();
            }

            return _mapper.Map<CategoryVM>(category);
        }


        public async Task<CategoryVM> Delete(int categoryId)
        {
            var category = await _dbContext.Categories!.FindAsync(categoryId);
            if (category == null)
            {
                new NotFoundResult();
            }
            else
            {
                _dbContext.Categories!.Remove(category);
                await _dbContext.SaveChangesAsync();
            }

            return _mapper.Map<CategoryVM>(category);
        }

    }
}
