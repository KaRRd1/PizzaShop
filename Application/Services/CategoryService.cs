using Application.Dtos;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryWithProductsResponse>> GetCategoriesWithProducts(CancellationToken cancellationToken = default)
    {
        var categories = await _categoryRepository.GetAllCategoriesWithProducts(cancellationToken);
        var categoryDtos = _mapper.Map<IEnumerable<CategoryWithProductsResponse>>(categories);

        return categoryDtos;
    }
}