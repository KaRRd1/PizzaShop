namespace Domain.Entities;

public class OrderProductVariation
{
    public Order Order { get; set; } = null!;
    public int OrderId { get; set; }
    public int ProductVariationId { get; set; }
    public ProductVariation ProductVariation { get; set; } = null!;
    public int Quantity { get; set; }
}