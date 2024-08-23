using Microsoft.AspNetCore.Mvc;
using MongoDb.DTOs.CategoryDTOs;
using MongoDb.Services.CategoryService;
using MongoDb.Settings;

namespace MongoDb.Controllers;
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _categoryService.GetAllCategoryAsync();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }
    [HttpPost]  
    public async Task<IActionResult> CreateCategory(CreateCategoryDTO DTO)
    {
        await _categoryService.CreateCategoryAsync(DTO);
        return RedirectToAction("Index");
    }
    public async Task DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);
    }

}
