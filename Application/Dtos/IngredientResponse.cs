using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos;

public class IngredientResponse : IMapWith<Ingredient>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Ingredient, IngredientResponse>();
    }
}