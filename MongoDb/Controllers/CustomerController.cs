using Microsoft.AspNetCore.Mvc;
using MongoDb.DTOs.CustomerDTOs;
using MongoDb.Services.CustomerService;

namespace MongoDb.Controllers;
public class CustomerController : Controller
{

    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _customerService.GetAllCustomerAsync();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateCustomer()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerDTO DTO)
    {
        await _customerService.CreateCustomerAsync(DTO);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> DeleteCustomer(string id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> UpdateCustomer(string id)
    {
        var values = await _customerService.GetByIdCustomerAsync(id);
        return View(values);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerDTO DTO)
    {
        await _customerService.UpdateCustomerAsync(DTO);
        return RedirectToAction("Index");
    }
}
