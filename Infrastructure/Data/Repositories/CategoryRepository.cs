using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ShopDbContext _context;

    public CategoryRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllSortedCategoriesByPosition(CancellationToken cancellationToken = default)
    {
        return await _context.Categories.OrderBy(category => category.Position).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesWithProducts(CancellationToken cancellationToken = default)
    {
        return await _context.Categories
            .OrderBy(category => category.Position)
            .Include(x => x.Products)
            .ThenInclude(product => product.Variations)
            .ThenInclude(variant => variant.Size)
            .ThenInclude(size => size.Unit)
            .Include(category => category.Products)
            .ThenInclude(product => product.Variations)
            .ThenInclude(variation => variation.Type)
            .Include(category => category.Products)
            .ThenInclude(category => category.Ingredients)
            .ToListAsync(cancellationToken);
    }
}