using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class OrderProductVariationConfiguration : IEntityTypeConfiguration<OrderProductVariation>
{
    public void Configure(EntityTypeBuilder<OrderProductVariation> builder)
    {
        builder.HasKey(orderProductVariation =>
            new { orderProductVariation.OrderId, orderProductVariation.ProductVariationId });

        builder
            .HasOne(orderProductVariation => orderProductVariation.Order)
            .WithMany(order => order.OrderProductVariations)
            .HasForeignKey(orderProductVariation => orderProductVariation.OrderId);
        
        builder
            .HasOne(orderProductVariation => orderProductVariation.ProductVariation)
            .WithMany(productVariation => productVariation.OrderProductVariations)
            .HasForeignKey(orderProductVariation => orderProductVariation.ProductVariationId);
    }
}