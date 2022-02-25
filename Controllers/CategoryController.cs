using Microsoft.AspNetCore.Mvc;
using Assignment11_EFCore_2.Services;
using Assignment11_EFCore_2.Models;
using Assignment11_EFCore_2.Data.Entities;
namespace Assignment11_EFCore_2.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _category;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService category)
    {
        _logger = logger;
        _category = category;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var data = await _category.GetAllAsync();
        var resultdata = from item in data
                            select new CategoryViewModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                            };
        return new JsonResult(resultdata);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        var data = await _category.GetOneAsync(id);
        if (data == null) return NotFound();


        return new JsonResult(new CategoryViewModel
        {
            Id = data.Id,
            Name = data.Name,
        });
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(CategoryCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Category
            {
                Name = model.Name,

            };
            var resultCategory = await _category.AddAsync(entity);
            return new JsonResult(resultCategory);
        }
        catch (System.Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditAsync(int id, CategoryEditModel model)
    {
        try
        {
            var data = await _category.GetOneAsync(id);
            if (data == null) return NotFound();
            
            data.Name = model.Name;


            var resultCategory = await _category.EditAsync(data);
            return new JsonResult(resultCategory);
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
            var data = await _category.GetOneAsync(id);
            if (data == null) return NotFound();
            else
            {
                await _category.RemoveAsync(data);
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
