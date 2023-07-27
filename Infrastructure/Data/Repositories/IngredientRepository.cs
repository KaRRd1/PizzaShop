using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly ShopDbContext _context;

    public IngredientRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<IngredientCategory>> GetCategoriesWithIngredients(CancellationToken cancellationToken = default)
    {
        return await _context.IngredientCategories
            .Include(category => category.Ingredients)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<IngredientCategory>> GetIngredientsFromProductCategory(int productCategoryId, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Where(x => x.Id == productCategoryId)
            .SelectMany(x => x.Products
                .SelectMany(z => z.Ingredients))
            .GroupBy(ingredient => ingredient.IngredientCategory, ingredient => ingredient)
            .Select(x => new IngredientCategory {Id = x.Key.Id, Name = x.Key.Name, Ingredients = x.Distinct().ToList()})
            .ToListAsync(cancellationToken);
    }
}