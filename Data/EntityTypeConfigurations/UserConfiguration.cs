using EcommerseBot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerseBot.Data.EntityTypeConfigurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id);
        builder.Property(u => u.Name).HasMaxLength(100);
        builder.Property(u => u.LanguageCode).HasMaxLength(3).IsRequired();
    }
}