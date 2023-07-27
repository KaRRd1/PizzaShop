using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllSortedCategoriesByPosition(CancellationToken cancellationToken = default);
    Task<IEnumerable<Category>> GetAllCategoriesWithProducts(CancellationToken cancellationToken = default);
}