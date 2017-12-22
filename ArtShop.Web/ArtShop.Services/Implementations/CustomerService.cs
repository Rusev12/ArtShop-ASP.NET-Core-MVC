namespace ArtShop.Services.Implementations
{
    using ArtShop.Data.DataModels;
    using Services.Interfaces;
    using Data;
    using ArtShop.Services.ServiceModels.ArtProduct;
    using ArtShop.Services.ServiceModels.Customer;
    using System.Linq;

    public class CustomerService : ICustomerService
    {
        private readonly ArtShopDbContext db;

        public CustomerService(ArtShopDbContext db)
        {
            this.db = db;
        }

        public CustomerServiceModel AddProductToUser(User user, AllArtProducts product)
        {
            var productsFromBase = db.ArtProducts
                 .Where(p => p.Id == product.Id)
                 .FirstOrDefault();
            
                user.ArtProducts.Add(productsFromBase);
                productsFromBase.IsAvailable = false;
                db.SaveChanges();
            

            var customerModel = new CustomerServiceModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                StreetAddress = user.StreetAddress,
                City = user.City,
                PostCode = user.PostCode
            };

            return customerModel;
        }

        public CustomerServiceModel ById(string id)
        {
            var user = db.Users
                .Where(u => u.Id == id)
                .Select(u => new CustomerServiceModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    City = u.City,
                    PostCode = u.PostCode,
                    StreetAddress = u.StreetAddress
                })
                .FirstOrDefault();

            return user;
        }
    }
}
