using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ArtShop.Data.DataModels;
using ArtShop.Services.ServiceModels.Customer;
using ArtShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ArtShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IArtProductService productService;
        private readonly ICustomerService customerService;

        public CustomerController(UserManager<User> _userManager, IArtProductService productService,  ICustomerService customerService)
        {
            this._userManager = _userManager;
            this.productService = productService;
            this.customerService = customerService;
        }
        
        [Authorize]
        public IActionResult Sell()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Sell(CustomerServiceModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return (View(model));
            }
            var modelProduct = productService.GetById(id);
          

            var user = await _userManager.GetUserAsync(HttpContext.User);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PostCode = model.PostCode;
            user.StreetAddress = model.StreetAddress;
            user.City = model.City;

            
            var userInfo = customerService.AddProductToUser(user, modelProduct);

            return RedirectToAction(nameof(InformationForSell));
           
        }
        [Authorize]
        public async Task<IActionResult> InformationForSell()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = customerService.ById(user.Id);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> CustomerProducts()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = productService.AllProductsByThisUser(user);
            return View(model);
        }
    }
}