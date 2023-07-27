using Application.Dtos;

namespace Application.Interfaces.Services;

public interface IIngredientService
{
    public Task<IEnumerable<IngredientCategoryResponse>> GetCategoriesWithIngredients(CancellationToken cancellationToken = default);
    public Task<IEnumerable<IngredientCategoryResponse>> GetIngredientsFromProductCategory(int productCategory, CancellationToken cancellationToken = default);
}