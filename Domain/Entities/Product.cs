using Domain.Entities.Common;

namespace Domain.Entities;

public class Product : NamedEntity
{
    public string Description { get; set; } = null!;
    public string ImageSmallUrl { get; set; } = null!;
    public string ImageLargeUrl { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int? TagId { get; set; }
    public Tag? Tag { get; set; }
    public ICollection<ProductVariation> Variations { get; set; } = null!;
    public ICollection<Ingredient>? Ingredients { get; set; }
}