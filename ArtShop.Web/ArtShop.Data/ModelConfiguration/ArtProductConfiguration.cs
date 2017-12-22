namespace ArtShop.Data.ModelConfiguration
{
    using DataModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArtProductConfiguration : IEntityTypeConfiguration<ArtProduct>
    {
        public void Configure(EntityTypeBuilder<ArtProduct> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Customer)
                .WithMany(c => c.ArtProducts)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

           

      
        }
    }
}

