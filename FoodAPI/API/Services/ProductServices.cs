using AutoMapper;
using Core.Configurations;
using Core.Models;
using Core.ViewModels;
using Core.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProductServices
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public ProductServices(ApplicationDBContext dBContext, IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }
        public async Task<ProductsVM> Create(ProductCategoryVM model)
        {
            var newProduct = _mapper.Map<Products>(model.Product);

            _dbContext.Products!.Add(newProduct);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductsVM>(newProduct);
        }

        public async Task<List<ProductsVM>> GetAll()
        {
            var products = await _dbContext.Products!.ToListAsync();
            return _mapper.Map<List<ProductsVM>>(products);
        }

        public async Task<ProductsVM> GetByID(int productID)
        {
            var product = await _dbContext.Products!.FirstOrDefaultAsync(c => c.ID == productID);
            return _mapper.Map<ProductsVM>(product);
        }

        public async Task<ProductsVM> Edit(int productID, ProductEditVM model)
        {
            var product = await _dbContext.Products!.FirstOrDefaultAsync(c => c.ID == productID);

            if (product == null)
            {
                new NotFoundResult();
            }
            else
            {
                product.ID = productID;
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                await _dbContext.SaveChangesAsync();
            }

            return _mapper.Map<ProductsVM>(product);
        }


        public async Task<ProductsVM> Delete(int productID)
        {
            var product = await _dbContext.Products!.FindAsync(productID);
            if (product == null)
            {
                new NotFoundResult();
            }
            else
            {
                _dbContext.Products!.Remove(product);
                await _dbContext.SaveChangesAsync();
            }

            return _mapper.Map<ProductsVM>(product);
        }

        public async Task<IActionResult> AddProductToCategories(List<string> categoryIDs, int productID)
        {
            var product = await _dbContext.Products!.FindAsync(productID);
            if (product == null)
            {
                return new NotFoundResult();
            }

            foreach (var categoryID in categoryIDs)
            {
                if (int.TryParse(categoryID, out int id) == false)
                {
                    Console.WriteLine($"CategoryID không hợp lệ: {categoryID}");
                    return new NotFoundResult();
                }

                Console.WriteLine($"Thêm sản phẩm {productID} vào danh mục {id}");

                _dbContext.ProductCategories!.Add(new ProductCategory() { ProductID = productID, CategoryID = id });
            }

            await _dbContext.SaveChangesAsync();
            return new OkResult();
        }

    }
}
