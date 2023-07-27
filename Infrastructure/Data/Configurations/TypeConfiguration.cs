using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = Domain.Entities.Type;

namespace Infrastructure.Data.Configurations;

public class TypeConfiguration : IEntityTypeConfiguration<Type>
{
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        builder.HasKey(type => type.Id);

        builder.Property(type => type.Name).HasMaxLength(20);
    }
}