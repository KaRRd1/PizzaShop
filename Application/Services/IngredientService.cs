using Application.Dtos;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;

    public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
    {
        _ingredientRepository = ingredientRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<IngredientCategoryResponse>> GetCategoriesWithIngredients(CancellationToken cancellationToken = default)
    {
        var ingredients = await _ingredientRepository.GetCategoriesWithIngredients(cancellationToken);
        var ingredientDtos = _mapper.Map<IEnumerable<IngredientCategoryResponse>>(ingredients);
        
        return ingredientDtos;
    }

    public async Task<IEnumerable<IngredientCategoryResponse>> GetIngredientsFromProductCategory(int productCategory, CancellationToken cancellationToken = default)
    {
        var ingredients = await _ingredientRepository.GetIngredientsFromProductCategory(productCategory, cancellationToken);
        var ingredientDtos = _mapper.Map<IEnumerable<IngredientCategoryResponse>>(ingredients);
        
        return ingredientDtos;
    }
}