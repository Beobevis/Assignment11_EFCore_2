using Microsoft.AspNetCore.Mvc;
using Assignment11_EFCore_2.Services;
using Assignment11_EFCore_2.Models;
using Assignment11_EFCore_2.Data.Entities;
namespace Assignment11_EFCore_2.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _product;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IProductService product)
    {
        _logger = logger;
        _product = product;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var data = await _product.GetAllAsync();
        var resultProduct = from item in data
                            select new ProductViewModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Manufacturer = item.Manufacturer,
                                CategoryId = item.CategoryId

                            };
        return new JsonResult(resultProduct);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        var data = await _product.GetOneAsync(id);
        if (data == null) return NotFound();


        return new JsonResult(new ProductViewModel
        {
            Id = data.Id,
            Name = data.Name,
            Manufacturer = data.Manufacturer,
            CategoryId = data.CategoryId
        });
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(ProductCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Product
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                CategoryId = model.CategoryId
            };
            var resultProduct = await _product.AddAsync(entity);
            return new JsonResult(resultProduct);
        }
        catch (System.Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditAsync(int id, ProductEditModel model)
    {
        try
        {
            var data = await _product.GetOneAsync(id);
            if (data == null) return NotFound();

            data.Name = model.Name;
            data.Manufacturer = model.Manufacturer;
            data.CategoryId = model.CategoryId;


            var resultProduct = await _product.EditAsync(data);
            return new JsonResult(resultProduct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }


    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        try
        {
            var data = await _product.GetOneAsync(id);
            if (data == null) return NotFound();
            else
            {
                await _product.RemoveAsync(data);
                return Ok();
            }
        }

        catch (IndexOutOfRangeException ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }




}
