using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICategoryService
{
    public Task<IEnumerable<CategoryWithProductsResponse>> GetCategoriesWithProducts(CancellationToken cancellationToken = default);
}