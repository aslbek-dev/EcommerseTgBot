using System.Collections.Immutable;
using EcommerseBot.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBot.Data.EntityTypeConfigurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseIdentityAlwaysColumn();

        builder.HasOne(b => b.User).WithOne();

        builder.HasMany(b => b.Products).WithOne();

    }
}
