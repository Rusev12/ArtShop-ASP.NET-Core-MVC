namespace ArtShop.Data
{
    using ArtShop.Data.DataModels;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;


    public class ArtShopDbContext : IdentityDbContext<User>
    {
        public ArtShopDbContext(DbContextOptions<ArtShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<ArtProduct> ArtProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
       
        }
    }
}
