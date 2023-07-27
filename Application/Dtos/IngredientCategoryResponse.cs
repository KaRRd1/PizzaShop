using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos;

public class IngredientCategoryResponse : IMapWith<IngredientCategory>
{
    public string Name { get; set; } = null!;
    public IEnumerable<IngredientResponse> Ingredients { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<IngredientCategory, IngredientCategoryResponse>();
    }
}