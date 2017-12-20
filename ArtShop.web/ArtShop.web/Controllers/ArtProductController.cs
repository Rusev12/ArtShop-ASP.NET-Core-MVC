namespace ArtShop.web.Controllers
{
    using ArtShop.Data.DataModels;
    using ArtShop.web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ReflectionIT.Mvc.Paging;
    using Services.Interfaces;
    using Services.ServiceModels;
    using System.IO;
    using System.Threading.Tasks;
    using System.Linq;
    using PagedList;
    using PagedList.Core.Mvc;
    using PagedList.Core;

    public class ArtProductController : Controller
    {
        private readonly IArtProductService service;
        private IHostingEnvironment _environment;

        public ArtProductController(IHostingEnvironment environment, IArtProductService service)
        {
            this._environment = environment;
            this.service = service;
        }


        public IActionResult All()
        {
            var products = service.ListAll();
            
            return View(products);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles =GlobalConstants.AdministarorRole)]
        public async Task<IActionResult> Create(ArtProducts model , IFormFile files)
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
                UrlPath = fileName
            };

            service.Create(artProduct);

            return RedirectToAction(nameof(All));
        }
    }
}