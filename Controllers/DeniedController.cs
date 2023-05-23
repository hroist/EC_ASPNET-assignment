using Microsoft.AspNetCore.Mvc;

namespace merketo.Controllers;

public class DeniedController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
