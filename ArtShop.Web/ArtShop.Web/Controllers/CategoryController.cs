
namespace ArtShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.ServiceModels.Category;
    using Services.Implementations;
    using Services.Interfaces;
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;
   
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var name = model.CategoryName;
            service.Create(name);
            return RedirectToAction(nameof(All));
        }

        public IActionResult All() => View();
        
    }
}