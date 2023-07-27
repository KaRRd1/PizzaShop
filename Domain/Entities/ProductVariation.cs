using Domain.Entities.Common;

namespace Domain.Entities;

public class ProductVariation : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int? WeightGrams { get; set; }
    public int Price { get; set; }
    public int? SizeId { get; set; }
    public Size? Size { get; set; }
    public int? TypeId { get; set; }
    public Type? Type { get; set; }
    public ICollection<OrderProductVariation> OrderProductVariations { get; set; } = null!;
}