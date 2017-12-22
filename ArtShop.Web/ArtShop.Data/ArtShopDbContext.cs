namespace ArtShop.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ArtShop.Data.DataModels;
    using ModelConfiguration;

    public class ArtShopDbContext : IdentityDbContext<User>
    {
        public ArtShopDbContext(DbContextOptions<ArtShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<ArtProduct> ArtProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<ProducsDistributors> ProductsDistributors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
   
            builder.ApplyConfiguration(new ArtProductConfiguration());
            builder.ApplyConfiguration(new ProductDistributorsConfiguration());
        }
    }
}
