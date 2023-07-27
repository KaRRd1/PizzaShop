using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext _context;

    public ProductRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProduct(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Include(product => product.Variations)
            .Include(product => product.Ingredients)
            .Include(product => product.Tag)
            .SingleAsync(product => product.Id == id, cancellationToken);
    }

    public async Task<bool> ProductVariationIsExist(int productVariationId, CancellationToken cancellationToken = default)
    {
        return await _context.ProductVariations
            .AnyAsync(variation => variation.Id == productVariationId, cancellationToken);
    }
}