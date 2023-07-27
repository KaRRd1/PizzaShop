using Domain.Entities.Common;

namespace Domain.Entities;

public class Category : NamedEntity
{
    public string Alias { get; set; } = null!;
    public int Position { get; set; }
    public ICollection<Product> Products { get; set; } = null!;
    // public ICollection<Size> Sizes { get; set; }
    // public ICollection<Type> Types { get; set; }
}