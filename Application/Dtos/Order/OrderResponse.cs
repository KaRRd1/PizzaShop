using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.Order;

public class OrderResponse : IMapWith<Domain.Entities.Order>
{
    public int OrderId { get; set; }
    public DateTime Date { get; set; }
    public string PaymentMethodName { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string House { get; set; } = null!;
    public string Apartment { get; set; } = null!;
    public IEnumerable<OrderProductVariationResponse> Products { get; set; } = null!;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Order, OrderResponse>()
            .ForMember(orderResponse => orderResponse.OrderId,
                options => options.MapFrom(order => order.Id))
            .ForMember(orderResponse => orderResponse.Products, 
                options => options.MapFrom(order => order.OrderProductVariations));
    }
}