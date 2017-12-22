namespace ArtShop.Data.ModelConfiguration
{

    using Microsoft.EntityFrameworkCore;
    using DataModels;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductDistributorsConfiguration : IEntityTypeConfiguration<ProducsDistributors>
    {
        public void Configure(EntityTypeBuilder<ProducsDistributors> builder)
        {
            builder
                .HasKey(pd => new { pd.ArtProductId, pd.DistributorId });

            builder
                .HasOne(pd => pd.ArtProduct)
                .WithMany(p => p.ProducsDistributors)
                .HasForeignKey(pd => pd.ArtProductId);

            builder
               .HasOne(pd => pd.Distributor)
               .WithMany(p => p.ProducsDistributors)
               .HasForeignKey(pd => pd.DistributorId);

        }
    }
}
