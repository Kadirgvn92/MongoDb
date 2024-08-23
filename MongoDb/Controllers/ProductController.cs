using Microsoft.AspNetCore.Mvc;
using MongoDb.DTOs.ProductDTOs;
using MongoDb.Services.ProductService;

namespace MongoDb.Controllers;
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _productService.GetAllProductAsync();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateProduct()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDTO dTO)
    {
        await _productService.CreateProductAsync(dTO);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        var values = await _productService.GetByIdProductAsync(id);
        return View(values);    
    }
    [HttpPost]  
    public async Task<IActionResult> UpdateProduct(UpdateProductDTO dTO)
    {
        await _productService.UpdateProductAsync(dTO);
        return RedirectToAction("Index");
    }
}
