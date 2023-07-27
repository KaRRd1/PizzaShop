using Domain.Entities.Common;

namespace Domain.Entities;

public class IngredientCategory : NamedEntity
{
    public ICollection<Ingredient> Ingredients { get; set; } = null!;
}