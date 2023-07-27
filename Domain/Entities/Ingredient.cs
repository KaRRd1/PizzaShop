using Domain.Entities.Common;

namespace Domain.Entities;

public class Ingredient : NamedEntity
{
    public int IngredientCategoryId { get; set; }
    public IngredientCategory IngredientCategory { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = null!;
}