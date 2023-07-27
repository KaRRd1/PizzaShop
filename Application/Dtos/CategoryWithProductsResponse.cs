using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos;

public class CategoryWithProductsResponse : IMapWith<Category>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public string Position { get; set; } = null!;
    public bool HasIngredients { get; set; }
    public IEnumerable<ProductResponse> Products { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryWithProductsResponse>()
            .ForMember(response => response.HasIngredients, 
                options => 
                    options.MapFrom(category => category.Products.Any(product => product.Ingredients.Any())));
    }
}