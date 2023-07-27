using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);
        
        builder.Property(product => product.Name).HasMaxLength(30);
        builder.Property(product => product.Description).HasMaxLength(120);
        builder.Property(product => product.ImageSmallUrl).HasMaxLength(500);
    }
}