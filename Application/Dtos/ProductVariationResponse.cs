using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Type = Domain.Entities.Type;

namespace Application.Dtos;

public class ProductVariationResponse : IMapWith<ProductVariation>
{
    public int Id { get; set; }
    public int Price { get; set; }
    public SizeResponse? Size { get; set; }
    public Type? Type { get; set; }
    public int? WeightGrams { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductVariation, ProductVariationResponse>();
    }
}