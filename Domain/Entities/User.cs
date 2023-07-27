using Domain.Entities.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string? Name { get; set; }
    public string Phone { get; set; } = null!;
    public string? Email { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    
    public ICollection<Order>? Orders { get; set; }
}