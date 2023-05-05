using merketo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace merketo.Controllers
{
    [Authorize(Roles = "SystemAdministrator")]
    public class AdminController : Controller
    {
        private readonly ProductService _productService;
        private readonly TagService _tagService;

        public AdminController(ProductService productService, TagService tagService)
        {
            _productService = productService;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult AddProducts()
        {
            ViewBag.Tags = _tagService.GetTags();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductAddViewModel productAddViewModel, string[] tags)
        {
            if (ModelState.IsValid)
            {
                var entity = await _productService.AddAsync(productAddViewModel);
                if (entity != null)
                {
                    await _tagService.AddTagsAsync(entity, tags);
                    return RedirectToAction("Products", "Admin");
                }
                    

                ModelState.AddModelError("", "Something went wrong when trying to add the product.");
            }
            ViewBag.Tags = _tagService.GetTags(tags);
            return View(productAddViewModel);
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}
