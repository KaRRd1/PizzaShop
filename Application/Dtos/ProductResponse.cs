using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos;

public class ProductResponse : IMapWith<Product>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageSmallUrl { get; set; } = null!;
    public string ImageLargeUrl { get; set; } = null!;
    public int CategoryId { get; set; }
    public Tag? Tag { get; set; }
    public IEnumerable<IngredientResponse> Ingredients { get; set; } = null!;
    public IEnumerable<ProductVariationResponse> Variations { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductResponse>();
    }
}