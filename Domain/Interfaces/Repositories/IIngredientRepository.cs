using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IIngredientRepository
{
    public Task<IEnumerable<IngredientCategory>> GetCategoriesWithIngredients(
        CancellationToken cancellationToken = default);

    public Task<IEnumerable<IngredientCategory>> GetIngredientsFromProductCategory(int productCategoryId,
        CancellationToken cancellationToken);
}