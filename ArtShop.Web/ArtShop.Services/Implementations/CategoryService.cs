namespace ArtShop.Services.Implementations
{
    using Services.Interfaces;
    using Data;
    using System.Linq;
    using ServiceModels.Category;
    using Data.DataModels;

    public class CategoryService : ICategoryService
    {
        private readonly ArtShopDbContext db;

        public CategoryService(ArtShopDbContext db)
        {
            this.db = db;
        }

        public void Create(string name)
        {
            var isCategoryExists = db.Categories.Any(c => c.CategoryName == name);

            if (!isCategoryExists)
            {
                var category = new Category
                {
                    CategoryName = name
                };

                this.db.Categories.Add(category);
                db.SaveChanges();

            }
        }
    }
}
