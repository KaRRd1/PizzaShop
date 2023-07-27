using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.Order;

public class OrderProductVariationRequest : IMapWith<OrderProductVariation>
{
    public int ProductVariationId { get; set; }
    public int Quantity { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderProductVariationRequest, OrderProductVariation>();
    }
}