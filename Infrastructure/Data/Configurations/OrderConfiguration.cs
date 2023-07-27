using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(order => order.Name).HasMaxLength(18);
        builder.Property(order => order.Email).HasMaxLength(40);
        builder.Property(order => order.Phone).HasMaxLength(20);
        builder.Property(order => order.Street).HasMaxLength(100);
        builder.Property(order => order.House).HasMaxLength(10);
        builder.Property(order => order.Comment).HasMaxLength(200);
    }
}