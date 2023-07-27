using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Type = Domain.Entities.Type;

namespace Application.Dtos.Order;

public class OrderProductVariationResponse : IMapWith<OrderProductVariation>
{
    public int ProductVariationId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public Type? Type { get; set; }
    public SizeResponse? Size { get; set; }
    public string ProductName { get; set; } = null!;
    public string ImageSmallUrl { get; set; } = null!;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderProductVariation, OrderProductVariationResponse>()
            .ForMember(orderProductVariationResponse => orderProductVariationResponse.Price,
                options => options.MapFrom(x => x.ProductVariation.Price))
            .ForMember(orderProductVariationResponse => orderProductVariationResponse.ProductName,
                options => options.MapFrom(x => x.ProductVariation.Product.Name))
            .ForMember(orderProductVariationResponse => orderProductVariationResponse.ImageSmallUrl,
                options => options.MapFrom(x => x.ProductVariation.Product.ImageSmallUrl))
            .ForMember(orderProductVariationResponse => orderProductVariationResponse.Size,
            options => options.MapFrom(x => x.ProductVariation.Size))
            .ForMember(orderProductVariationResponse => orderProductVariationResponse.Type,
            options => options.MapFrom(x => x.ProductVariation.Type));
    }
}