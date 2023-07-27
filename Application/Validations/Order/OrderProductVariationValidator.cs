using Application.Dtos.Order;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Application.Validations.Order;

public class OrderProductVariationValidator : AbstractValidator<OrderProductVariationRequest>
{
    private readonly IProductRepository _productRepository;
    
    public OrderProductVariationValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        RuleFor(orderProductVariation => orderProductVariation.ProductVariationId).MustAsync(IsExist);
        RuleFor(orderProductVariation => orderProductVariation.Quantity).ExclusiveBetween(0, 100);
    }

    private async Task<bool> IsExist(int id, CancellationToken cancellationToken)
    {
        return await _productRepository.ProductVariationIsExist(id, cancellationToken);
    }
}