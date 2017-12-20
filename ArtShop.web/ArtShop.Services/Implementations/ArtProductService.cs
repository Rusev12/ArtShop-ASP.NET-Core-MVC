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


    public class ArtProductService : IArtProductService
    {
        private readonly ArtShopDbContext db;

        public ArtProductService(ArtShopDbContext db)
        {
            this.db = db;
        }

        public void Create(ArtProducts model)
        {
            var artProduct = new ArtProduct
            {
                Name = model.Name,
                Description = model.Description,
                UrlPath = model.UrlPath,
                Price = model.Price
            };

            this.db.ArtProducts.Add(artProduct);
            db.SaveChanges();
        }

        public  IEnumerable<AllArtProducts> ListAll()
        {
            var products = db.ArtProducts
               .AsNoTracking()
               .ProjectTo<AllArtProducts>()
               .OrderByDescending(p => p.Price)
               .ToList();

         
            return products;
        }
        
    }
}
