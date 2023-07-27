using Domain.Entities.Common;

namespace Domain.Entities;

public class Size : BaseEntity
{
    public double Value { get; set; }
    public int UnitId { get; set; }
    public Unit Unit { get; set; } = null!;
    // public ICollection<Category> Categories { get; set; }
}