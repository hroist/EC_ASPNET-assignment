using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Search()
    {
        return View();
    }

    public IActionResult Details(Guid articleNumber)
    {
        ViewBag.ArticleNumber = articleNumber;
        return View();
    }
}
