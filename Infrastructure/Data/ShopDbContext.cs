using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Type = Domain.Entities.Type;

namespace Infrastructure.Data;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<IngredientCategory> IngredientCategories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductVariation> ProductVariations { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
}