using Domain.Entities.Common;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Email { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Street { get; set; } = null!;
    public string House { get; set; } = null!;
    public int? Entrance { get; set; }
    public int? Floor { get; set; }
    public int? Apartment { get; set; }
    public string? Comment { get; set; }
    public int StatusId { get; set; }
    public OrderStatus Status { get; set; } = null!;
    public int? UserId { get; set; }
    public User? User { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public ICollection<OrderProductVariation> OrderProductVariations { get; set; } = null!;
}