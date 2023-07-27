namespace Domain.Entities.Common;

public abstract class NamedEntity : BaseEntity
{
    public string Name { get; set; } = null!;
}