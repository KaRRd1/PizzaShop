using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.Order;

public class CreateOrderRequest : IMapWith<Domain.Entities.Order>
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Email { get; set; }
    public string Street { get; set; } = null!;
    public string House { get; set; } = null!;
    public int? Entrance { get; set; }
    public int? Floor { get; set; }
    public int? Apartment { get; set; }
    public string? Comment { get; set; }
    public int PaymentMethodId { get; set; }
    public IEnumerable<OrderProductVariationRequest> ProductVariations { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderRequest, Domain.Entities.Order>()
            .ForMember(order => order.OrderProductVariations, 
                options => options.MapFrom(orderRequest => orderRequest.ProductVariations));
    }
}