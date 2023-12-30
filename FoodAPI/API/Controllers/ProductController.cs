using API.Services;
using Core.Helpers;
using Core.ViewModels;
using Core.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly ProductServices _productServices;

    public ProductController(ProductServices productServices)
    {
        _productServices = productServices;
    }

    [HttpPost]
    [Authorize(Roles = AppRoleIdentity.Admin)]
    public async Task<IActionResult> Create([FromBody] ProductCategoryVM model)
    {
        var result = await _productServices.Create(model);

        if (result == null)
        {
            return BadRequest(result);
        }

        await _productServices.AddProductToCategories(model.CategoryIDs!, result.ID);

        return Ok(result);
    }



    [HttpGet]
    [Authorize(Roles = AppRoleIdentity.Customer )]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productServices.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByID(int id)
    {
        var result = await _productServices.GetByID(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, ProductEditVM model)
    {
        var result = await _productServices.Edit(id, model);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productServices.Delete(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
