using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<Product> GetProduct(int id, CancellationToken cancellationToken = default);
    Task<bool> ProductVariationIsExist(int productVariationId, CancellationToken cancellationToken = default);
}