namespace ArtShop.Services.Implementations
{
    using System.Collections.Generic;
    using ArtShop.Services.ServiceModels;
    using Data;
    using Interfaces;
    using ArtShop.Data.DataModels;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using ServiceModels.ArtProduct;

    public class ArtProductService : IArtProductService
    {
        private readonly ArtShopDbContext db;

        public ArtProductService(ArtShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserProduct> AllProductsByThisUser(User user)
        {
            var products =
                db.ArtProducts
                .Where(p => p.CustomerId == user.Id)
                .ProjectTo<UserProduct>()
                .ToList();

            return products;
        }

        public void Create(ArtProducts model)
        {
            var artProduct = new ArtProduct
            {
                Name = model.Name,
                Description = model.Description,
                UrlPath = model.UrlPath,
                Price = model.Price,
                Brand = model.Brand,
                IsAvailable = true

            };

            this.db.ArtProducts.Add(artProduct);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.ArtProducts
                .Where(p => p.Id == id)
                .FirstOrDefault();

            db.ArtProducts.Remove(product);
            db.SaveChanges();
        }

        public AllArtProducts GetById(int id)
        {
            var product = db.ArtProducts
                 .Where(p => p.Id == id)
                .ProjectTo<AllArtProducts>()            
                .FirstOrDefault();

            return product;
        }

        public IEnumerable<AllArtProducts> ListAll(int page)
        {
            var pageSize = 6;

            var products = db.ArtProducts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
               .ProjectTo<AllArtProducts>()
               .OrderByDescending(p => p.Price)
               .ToList();


            return products;
        }

        public void Update(AllArtProducts model , int id)
        {
            var products = db.ArtProducts
                .Where(p => p.Id == id)
                .FirstOrDefault();

            products.Brand = model.Brand;
            products.Name = model.Name;
            products.Price = model.Price;
            products.UrlPath = model.UrlPath;
            products.Description = model.Description;

            this.db.SaveChanges();
        }
    }
}

