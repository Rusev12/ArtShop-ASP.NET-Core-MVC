namespace ArtShop.web.Controllers
{
    using ArtShop.Data.DataModels;
    using ArtShop.web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ServiceModels;
    using System.IO;
    using System.Threading.Tasks;
    using System.Linq;
    using Services.ServiceModels.ArtProduct;

    public class ArtProductController : Controller
    {
        private readonly IArtProductService service;
        private IHostingEnvironment _environment;

        public ArtProductController(IHostingEnvironment environment, IArtProductService service)
        {
            this._environment = environment;
            this.service = service;
        }

        public IActionResult ConfirmDelete(int id)
        {

            var product = service.GetById(id);
            return View(product);
        }
        public IActionResult Update(int id)
        {
            var product = service.GetById(id);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = GlobalConstants.AdministarorRole)]
        public async Task<IActionResult> Update(AllArtProducts model, int id, IFormFile files)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var uploads = Path.Combine(_environment.WebRootPath, "images");

            if (files.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, files.FileName), FileMode.Create))
                {
                    await files.CopyToAsync(fileStream);
                }
            }
            var fileName = Path.Combine(files.FileName);


            var artProduct = new AllArtProducts
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                UrlPath = fileName,
                Brand = model.Brand

            };

            service.Update(artProduct, id);

            return RedirectToAction(nameof(All));


        }
        [Authorize(Roles = GlobalConstants.AdministarorRole)]
        public IActionResult Delete(int id)
        {
            service.Delete(id);

            return RedirectToAction(nameof(All));
        }


        public IActionResult All(int page = 1)
        {
            var products = service.ListAll(page);
            ViewBag.CurrentPage = page;
            return View(products);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministarorRole)]
        public async Task<IActionResult> Create(ArtProducts model, IFormFile files)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var uploads = Path.Combine(_environment.WebRootPath, "images");

            if (files.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, files.FileName), FileMode.Create))
                {
                    await files.CopyToAsync(fileStream);
                }
            }
            var fileName = Path.Combine(files.FileName);


            var artProduct = new ArtProducts
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                UrlPath = fileName,
                Brand = model.Brand,
                IsAvailable = true
                
            };

            service.Create(artProduct);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id)
        {
            var product = service.GetById(id);
            return View(product);
        }

    }
}