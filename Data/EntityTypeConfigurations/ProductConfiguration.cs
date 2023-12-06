using EcommerseBot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerseBot.Data.EntityTypeConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
                .HasKey(p => p.Id);
        
        builder
                .HasIndex(p => p.Name);
        
        builder
                .Property(p => p.Id).UseIdentityAlwaysColumn();

        builder
                .HasOne(p => p.Photo)
                .WithOne(p => p.Product)
                .HasForeignKey<Product>(p => p.PhotoId)
                .IsRequired(false); //vaqtincha!!!
    }
}
