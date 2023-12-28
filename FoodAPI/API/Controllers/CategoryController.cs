using API.Services;
using Core.Models;
using Core.ViewModels.Categories;
using Core.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryServices _categoryServices;

        public CategoryController(CategoryServices categoryServices) 
        {
            _categoryServices = categoryServices;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM model)
        {
            var result = await _categoryServices.Create(model);
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryServices.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _categoryServices.GetByID(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(int id, CategoryEditVM model)
        {
            var result = await _categoryServices.Edit(id, model);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryServices.Delete(id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
